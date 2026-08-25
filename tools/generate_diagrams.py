#!/usr/bin/env python3
"""Generate the UML diagrams used by the pattern documentation.

Every diagram is described declaratively in diagram_specs.py and rendered to a
self contained SVG under docs/diagrams. The rendering is deterministic, so
running this script twice produces byte identical output and a diagram change
always shows up as a reviewable diff.

Usage:
    python3 tools/generate_diagrams.py [--check]

--check renders into memory and fails if any committed file is out of date.
"""

from __future__ import annotations

import argparse
import glob
import os
import re
import sys
from dataclasses import dataclass, field
from typing import Iterable

# --------------------------------------------------------------------------
# Palette. Dark on purpose: the panel carries its own background, so the same
# file reads correctly on a light page and on a dark one.
# --------------------------------------------------------------------------

CANVAS = "#0d1117"
CANVAS_EDGE = "#21262d"
BOX = "#161b22"
BOX_EDGE = "#30363d"
TEXT = "#e6edf3"
MUTED = "#8b949e"
FAINT = "#6e7681"

ACCENT = {
    "creational": "#3fb950",
    "structural": "#58a6ff",
    "behavioral": "#bc8cff",
    "neutral": "#8b949e",
}

SANS = "Segoe UI, -apple-system, BlinkMacSystemFont, Helvetica, Arial, sans-serif"
MONO = "ui-monospace, SFMono-Regular, Menlo, Consolas, monospace"

# Layout constants, in pixels.
PAD = 24            # canvas padding
TITLE_H = 34        # room for the diagram title
HEADER_H = 30       # class box header band
ROW_H = 19          # one member line
BOX_PAD_Y = 9       # vertical padding inside the member area
COL_GAP = 46        # horizontal gap between columns
ROW_GAP = 54        # vertical gap between rows
CHAR_W = 6.75       # advance width of the monospace face at 11.5px
NAME_CHAR_W = 7.7   # advance width of the header face at 13px
MIN_BOX_W = 132


@dataclass
class Node:
    key: str
    name: str
    col: int
    row: int
    stereotype: str = ""
    members: list[str] = field(default_factory=list)
    accent: str = ""
    # computed
    x: float = 0.0
    y: float = 0.0
    w: float = 0.0
    h: float = 0.0

    @property
    def cx(self) -> float:
        return self.x + self.w / 2

    @property
    def cy(self) -> float:
        return self.y + self.h / 2


@dataclass
class Edge:
    src: str
    dst: str
    kind: str = "uses"   # inherits | uses | holds
    label: str = ""


@dataclass
class Diagram:
    slug: str
    title: str
    category: str
    nodes: list[Node]
    edges: list[Edge] = field(default_factory=list)
    caption: str = ""


def esc(text: str) -> str:
    return (
        text.replace("&", "&amp;")
        .replace("<", "&lt;")
        .replace(">", "&gt;")
        .replace('"', "&quot;")
    )


def measure(node: Node) -> None:
    widest = len(node.name) * NAME_CHAR_W
    if node.stereotype:
        widest = max(widest, len(node.stereotype) * CHAR_W)
    for m in node.members:
        widest = max(widest, len(m) * CHAR_W)
    node.w = max(MIN_BOX_W, round(widest + 30))
    node.h = HEADER_H + (BOX_PAD_Y * 2 + len(node.members) * ROW_H if node.members else 6)
    if node.stereotype:
        node.h += 15


def place(diagram: Diagram) -> tuple[float, float]:
    nodes = diagram.nodes
    loops = {e.src for e in diagram.edges if e.src == e.dst}
    for n in nodes:
        measure(n)
        if not n.accent:
            n.accent = ACCENT[diagram.category]

    cols = sorted({n.col for n in nodes})
    rows = sorted({n.row for n in nodes})
    col_w = {c: max(n.w for n in nodes if n.col == c) for c in cols}
    row_h = {r: max(n.h for n in nodes if n.row == r) for r in rows}

    col_x, x = {}, float(PAD)
    for c in cols:
        col_x[c] = x
        x += col_w[c] + COL_GAP
    total_w = x - COL_GAP + PAD

    # A self loop on the first row needs clearance under the title.
    top = float(PAD + TITLE_H)
    if any(n.key in loops and n.row == rows[0] for n in nodes):
        top += 22
    row_y, y = {}, top
    for r in rows:
        row_y[r] = y
        y += row_h[r] + ROW_GAP
    total_h = y - ROW_GAP + PAD
    if diagram.caption:
        total_h += 26

    for n in nodes:
        # centre each box inside its column and align it to the top of its row
        n.x = round(col_x[n.col] + (col_w[n.col] - n.w) / 2, 1)
        n.y = round(row_y[n.row], 1)

    if loops:
        reach = max(n.x + n.w + 34 + PAD for n in nodes if n.key in loops)
        total_w = max(total_w, reach)

    return round(total_w), round(total_h)


def draw_box(n: Node) -> str:
    parts = []
    parts.append(
        f'<rect x="{n.x}" y="{n.y}" width="{n.w}" height="{n.h}" rx="7" '
        f'fill="{BOX}" stroke="{BOX_EDGE}" stroke-width="1"/>'
    )
    # header band, tinted with the category accent
    parts.append(
        f'<path d="M{n.x} {n.y + 7} a7 7 0 0 1 7 -7 h{n.w - 14} a7 7 0 0 1 7 7 '
        f'v{HEADER_H - 7} h-{n.w} z" fill="{n.accent}" fill-opacity="0.13"/>'
    )
    parts.append(
        f'<line x1="{n.x}" y1="{n.y + HEADER_H}" x2="{n.x + n.w}" y2="{n.y + HEADER_H}" '
        f'stroke="{n.accent}" stroke-opacity="0.4" stroke-width="1"/>'
    )
    parts.append(
        f'<text x="{n.cx}" y="{n.y + 20}" font-family="{SANS}" font-size="13" '
        f'font-weight="600" fill="{TEXT}" text-anchor="middle">{esc(n.name)}</text>'
    )
    ty = n.y + HEADER_H + BOX_PAD_Y + 4
    if n.stereotype:
        parts.append(
            f'<text x="{n.cx}" y="{ty + 5}" font-family="{MONO}" font-size="10.5" '
            f'fill="{n.accent}" text-anchor="middle" letter-spacing="0.4">'
            f'{esc(n.stereotype)}</text>'
        )
        ty += 15
    for i, m in enumerate(n.members):
        parts.append(
            f'<text x="{n.x + 14}" y="{ty + 8 + i * ROW_H}" font-family="{MONO}" '
            f'font-size="11.5" fill="{MUTED}">{esc(m)}</text>'
        )
    return "\n  ".join(parts)


def self_loop(a: Node) -> list[tuple[float, float]]:
    """A node that refers to another instance of itself, drawn as a side loop."""
    y = a.y + a.h * 0.55
    return [
        (a.x + a.w, y),
        (a.x + a.w + 30, y),
        (a.x + a.w + 30, a.y - 20),
        (a.x + a.w * 0.72, a.y - 20),
        (a.x + a.w * 0.72, a.y),
    ]


def route(a: Node, b: Node, lane: int = 0) -> list[tuple[float, float]]:
    """Orthogonal route from a to b. b is the arrow end.

    lane shifts parallel edges between the same pair apart, so that a class that
    both extends and holds another one shows two distinguishable lines.
    """
    if a is b:
        return self_loop(a)
    if lane:
        shift = 16 * lane
        a = Node(a.key, a.name, a.col, a.row, x=a.x + shift, y=a.y, w=a.w, h=a.h)
        b = Node(b.key, b.name, b.col, b.row, x=b.x + shift, y=b.y, w=b.w, h=b.h)
    if a.col == b.col:
        if a.row < b.row:
            return [(a.cx, a.y + a.h), (a.cx, b.y)]
        return [(a.cx, a.y), (a.cx, b.y + b.h)]
    if a.row == b.row:
        if a.col < b.col:
            return [(a.x + a.w, a.cy), (b.x, b.cy)]
        return [(a.x, a.cy), (b.x + b.w, b.cy)]
    # different column and different row: leave vertically, turn once
    if a.row < b.row:
        mid = (a.y + a.h + b.y) / 2 + 12 * lane
        return [(a.cx, a.y + a.h), (a.cx, mid), (b.cx, mid), (b.cx, b.y)]
    mid = (b.y + b.h + a.y) / 2 + 12 * lane
    return [(a.cx, a.y), (a.cx, mid), (b.cx, mid), (b.cx, b.y + b.h)]


def shorten(points: list[tuple[float, float]], amount: float) -> list[tuple[float, float]]:
    """Pull the final point back, leaving room for the arrow head."""
    (x1, y1), (x2, y2) = points[-2], points[-1]
    dx, dy = x2 - x1, y2 - y1
    length = (dx * dx + dy * dy) ** 0.5 or 1
    return points[:-1] + [(round(x2 - dx / length * amount, 1), round(y2 - dy / length * amount, 1))]


def head(points: list[tuple[float, float]], kind: str, colour: str) -> str:
    (x1, y1), (x2, y2) = points[-2], points[-1]
    dx, dy = x2 - x1, y2 - y1
    length = (dx * dx + dy * dy) ** 0.5 or 1
    ux, uy = dx / length, dy / length
    px, py = -uy, ux
    if kind == "inherits":
        size, half = 11.0, 6.0
        tip = (x2 + ux * size, y2 + uy * size)
        p1 = (x2 + px * half, y2 + py * half)
        p2 = (x2 - px * half, y2 - py * half)
        pts = " ".join(f"{round(x, 1)},{round(y, 1)}" for x, y in (tip, p1, p2))
        return f'<polygon points="{pts}" fill="{CANVAS}" stroke="{colour}" stroke-width="1.4"/>'
    size, half = 9.0, 4.2
    tip = (x2 + ux * size, y2 + uy * size)
    p1 = (x2 + px * half, y2 + py * half)
    p2 = (x2 - px * half, y2 - py * half)
    pts = " ".join(f"{round(x, 1)},{round(y, 1)}" for x, y in (tip, p1, p2))
    return f'<polygon points="{pts}" fill="{colour}"/>'


def diamond(points: list[tuple[float, float]], colour: str) -> str:
    (x1, y1), (x2, y2) = points[0], points[1]
    dx, dy = x2 - x1, y2 - y1
    length = (dx * dx + dy * dy) ** 0.5 or 1
    ux, uy = dx / length, dy / length
    px, py = -uy, ux
    a = (x1, y1)
    b = (x1 + ux * 6 + px * 4.5, y1 + uy * 6 + py * 4.5)
    c = (x1 + ux * 12, y1 + uy * 12)
    d = (x1 + ux * 6 - px * 4.5, y1 + uy * 6 - py * 4.5)
    pts = " ".join(f"{round(x, 1)},{round(y, 1)}" for x, y in (a, b, c, d))
    return f'<polygon points="{pts}" fill="{CANVAS}" stroke="{colour}" stroke-width="1.4"/>'


def draw_edge(e: Edge, index: dict[str, Node], accent: str, lane: int = 0) -> str:
    a, b = index[e.src], index[e.dst]
    pts = route(a, b, lane)
    colour = accent if e.kind == "inherits" else FAINT
    # An aggregation carries a diamond at the owning end and no arrow head, so the
    # line is only pulled back for the two kinds that do have one.
    pts = shorten(pts, 11 if e.kind == "inherits" else 9) if e.kind != "holds" else pts
    path = "M" + " L".join(f"{round(x, 1)} {round(y, 1)}" for x, y in pts)
    dash = ' stroke-dasharray="5 4"' if e.kind == "uses" else ""
    out = [
        f'<path d="{path}" fill="none" stroke="{colour}" stroke-width="1.4" '
        f'stroke-linejoin="round"{dash}/>'
    ]
    if e.kind == "holds":
        out.append(diamond(pts, colour))
    else:
        out.append(head(pts, e.kind, colour))
    if e.label:
        lx, ly = pts[len(pts) // 2]
        if len(pts) == 2:
            lx = (pts[0][0] + pts[1][0]) / 2
            ly = (pts[0][1] + pts[1][1]) / 2
        out.append(
            f'<rect x="{round(lx - len(e.label) * 3.1 - 5, 1)}" y="{round(ly - 8, 1)}" '
            f'width="{round(len(e.label) * 6.2 + 10, 1)}" height="16" rx="4" fill="{CANVAS}"/>'
        )
        out.append(
            f'<text x="{round(lx, 1)}" y="{round(ly + 4, 1)}" font-family="{MONO}" '
            f'font-size="10" fill="{FAINT}" text-anchor="middle">{esc(e.label)}</text>'
        )
    return "\n  ".join(out)


def render(d: Diagram) -> str:
    w, h = place(d)
    index = {n.key: n for n in d.nodes}
    accent = ACCENT[d.category]

    body = [
        f'<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 {w} {h}" width="{w}" '
        f'height="{h}" role="img" aria-label="{esc(d.title)}">',
        f'  <rect x="0.5" y="0.5" width="{w - 1}" height="{h - 1}" rx="10" fill="{CANVAS}" '
        f'stroke="{CANVAS_EDGE}"/>',
        f'  <rect x="{PAD}" y="{PAD - 2}" width="3" height="14" rx="1.5" fill="{accent}"/>',
        f'  <text x="{PAD + 12}" y="{PAD + 10}" font-family="{SANS}" font-size="13" '
        f'font-weight="600" fill="{TEXT}">{esc(d.title)}</text>',
    ]
    seen: dict[tuple[str, str], int] = {}
    for e in d.edges:
        pair = tuple(sorted((e.src, e.dst)))
        lane = seen.get(pair, 0)
        seen[pair] = lane + 1
        body.append("  " + draw_edge(e, index, accent, lane))
    for n in d.nodes:
        body.append("  " + draw_box(n))
    if d.caption:
        body.append(
            f'  <text x="{PAD}" y="{h - PAD + 4}" font-family="{SANS}" font-size="11" '
            f'fill="{FAINT}">{esc(d.caption)}</text>'
        )
    body.append("</svg>")
    return "\n".join(body) + "\n"


# --------------------------------------------------------------------------
# The catalogue map. Not a class diagram, so it has its own small renderer.
# --------------------------------------------------------------------------

CATALOGUE = [
    ("Creational", "creational", "object creation",
     ["Abstract Factory", "Builder", "Factory Method", "Prototype", "Singleton"]),
    ("Structural", "structural", "object composition",
     ["Adapter", "Bridge", "Composite", "Decorator", "Facade", "Flyweight", "Proxy"]),
    ("Behavioral", "behavioral", "object interaction",
     ["Chain of Responsibility", "Command", "Interpreter", "Iterator", "Mediator",
      "Memento", "Observer", "State", "Strategy", "Template Method", "Visitor"]),
]


def render_catalogue() -> str:
    col_w, gap, top = 268.0, 26.0, 96.0
    line_h, head_h, pad_in = 25.0, 54.0, 16.0
    rows = max(len(items) for *_, items in CATALOGUE)
    panel_h = head_h + pad_in * 2 + rows * line_h
    w = round(PAD * 2 + col_w * 3 + gap * 2)
    h = round(top + panel_h + PAD + 24)

    out = [
        f'<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 {w} {h}" width="{w}" '
        f'height="{h}" role="img" aria-label="The twenty-three Gang of Four patterns">',
        f'  <rect x="0.5" y="0.5" width="{w - 1}" height="{h - 1}" rx="10" fill="{CANVAS}" '
        f'stroke="{CANVAS_EDGE}"/>',
        f'  <text x="{PAD}" y="{PAD + 18}" font-family="{SANS}" font-size="18" '
        f'font-weight="600" fill="{TEXT}">The twenty-three Gang of Four patterns</text>',
        f'  <text x="{PAD}" y="{PAD + 40}" font-family="{SANS}" font-size="12.5" '
        f'fill="{MUTED}">Three families, divided by what a pattern is concerned with.</text>',
    ]

    for i, (name, key, subtitle, items) in enumerate(CATALOGUE):
        accent = ACCENT[key]
        x = PAD + i * (col_w + gap)
        out.append(
            f'  <rect x="{x}" y="{top}" width="{col_w}" height="{panel_h}" rx="9" '
            f'fill="{BOX}" stroke="{BOX_EDGE}"/>'
        )
        out.append(
            f'  <path d="M{x} {top + 9} a9 9 0 0 1 9 -9 h{col_w - 18} a9 9 0 0 1 9 9 '
            f'v{head_h - 9} h-{col_w} z" fill="{accent}" fill-opacity="0.12"/>'
        )
        out.append(
            f'  <line x1="{x}" y1="{top + head_h}" x2="{x + col_w}" y2="{top + head_h}" '
            f'stroke="{accent}" stroke-opacity="0.42"/>'
        )
        out.append(
            f'  <rect x="{x + pad_in}" y="{top + 15}" width="3" height="14" rx="1.5" '
            f'fill="{accent}"/>'
        )
        out.append(
            f'  <text x="{x + pad_in + 12}" y="{top + 26}" font-family="{SANS}" '
            f'font-size="14" font-weight="600" fill="{TEXT}">{esc(name)}</text>'
        )
        out.append(
            f'  <text x="{x + pad_in + 12}" y="{top + 43}" font-family="{MONO}" '
            f'font-size="10.5" fill="{accent}">{esc(subtitle)}</text>'
        )
        out.append(
            f'  <text x="{x + col_w - pad_in}" y="{top + 26}" font-family="{MONO}" '
            f'font-size="13" fill="{FAINT}" text-anchor="end">{len(items)}</text>'
        )
        for j, item in enumerate(items):
            iy = top + head_h + pad_in + 14 + j * line_h
            out.append(
                f'  <circle cx="{x + pad_in + 4}" cy="{round(iy - 4, 1)}" r="2.6" '
                f'fill="{accent}" fill-opacity="0.75"/>'
            )
            out.append(
                f'  <text x="{x + pad_in + 16}" y="{round(iy, 1)}" font-family="{SANS}" '
                f'font-size="12.5" fill="{TEXT}">{esc(item)}</text>'
            )

    out.append(
        f'  <text x="{PAD}" y="{h - PAD + 6}" font-family="{SANS}" font-size="11" '
        f'fill="{FAINT}">Every pattern has a folder, an explanation, a worked example, '
        f'and tests.</text>'
    )
    out.append("</svg>")
    return "\n".join(out) + "\n"


# --------------------------------------------------------------------------
# Source verification. A diagram that names a method the code does not have is
# worse than no diagram, so --check reads the C# sources and confirms every
# class name and every member label. The parsing is deliberately simple: the
# codebase uses one type per file and plain declarations.
# --------------------------------------------------------------------------

TYPE_RE = re.compile(
    r"^\s*(?:public |internal |protected |private )?(?:sealed |abstract |static |partial )*"
    r"(?:class|interface|record|struct)\s+([A-Za-z_]\w*)", re.M)
MEMBER_RE = re.compile(
    r"^\s*(?:\[[^\]]*\]\s*)*(?:public |internal |protected |private )?"
    r"(?:static |readonly |volatile |abstract |virtual |override |sealed |async |const |extern |new )*"
    r"[\w<>?\[\],. ]+?\s+([A-Za-z_]\w*)\s*(?:\(|=>|\{|;|=)", re.M)


def source_members(root: str) -> dict[str, set[str]]:
    """Map every declared type to the member names it declares."""
    found: dict[str, set[str]] = {}
    for path in sorted(glob.glob(os.path.join(root, "**", "*.cs"), recursive=True)):
        text = open(path, encoding="utf-8-sig").read()
        starts = [(m.start(), m.group(1)) for m in TYPE_RE.finditer(text)]
        if not starts:
            continue
        for i, (pos, name) in enumerate(starts):
            end = starts[i + 1][0] if i + 1 < len(starts) else len(text)
            body = text[pos:end]
            names = found.setdefault(name, set())
            for m in MEMBER_RE.finditer(body):
                names.add(m.group(1))
            # interface members carry no modifier and no body
            for m in re.finditer(r"^\s*[\w<>?\[\],. ]+?\s+([A-Za-z_]\w*)\s*(?:\(|\{)",
                                 body, re.M):
                names.add(m.group(1))
    return found


def label_identifier(label: str) -> str:
    """The member name inside a UML label such as '+ Save(path) : void'."""
    text = re.sub(r"^[+\-#]\s*", "", label).strip()
    if "(" in text:
        return text.split("(")[0].strip().split()[-1]
    if " : " in text:
        return text.split(" : ")[0].strip().split()[-1]
    return text.split()[-1] if text.split() else ""


def verify_against_source(diagrams, root: str, ignore: set[str]) -> list[str]:
    declared = source_members(root)
    problems = []
    for d in diagrams:
        for node in d.nodes:
            cls = node.name.split("<")[0]
            if cls in ignore:
                continue
            if cls not in declared:
                problems.append(f"{d.slug}: no type named {cls}")
                continue
            for label in node.members:
                ident = label_identifier(label)
                if not re.fullmatch(r"[A-Za-z_]\w*", ident) or ident == cls:
                    continue
                if ident not in declared[cls]:
                    problems.append(f"{d.slug}: {cls} has no member {ident}")
    return problems


def main(argv: Iterable[str]) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--check", action="store_true")
    args = parser.parse_args(list(argv))

    sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
    from diagram_specs import DIAGRAMS  # noqa: E402

    repo = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
    # Client is a stand in for whoever calls the pattern, and has no source file.
    problems = verify_against_source(
        DIAGRAMS, os.path.join(repo, "src", "DotnetDesignPatterns"), {"Client"})
    if problems:
        print("the diagrams disagree with the source:")
        for p in problems:
            print("  " + p)
        return 1

    out_dir = os.path.join(os.path.dirname(os.path.dirname(os.path.abspath(__file__))),
                           "docs", "diagrams")
    os.makedirs(out_dir, exist_ok=True)

    stale = []
    for slug, svg in [("catalogue", render_catalogue())] + [(d.slug, render(d)) for d in DIAGRAMS]:
        path = os.path.join(out_dir, f"{slug}.svg")
        if args.check:
            current = open(path, encoding="utf-8").read() if os.path.exists(path) else ""
            if current != svg:
                stale.append(slug)
        else:
            with open(path, "w", encoding="utf-8", newline="\n") as fh:
                fh.write(svg)

    if args.check:
        if stale:
            print("out of date: " + ", ".join(stale))
            return 1
        print(f"all {len(DIAGRAMS) + 1} diagrams are up to date")
        return 0

    print(f"wrote {len(DIAGRAMS) + 1} diagrams to docs/diagrams")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
