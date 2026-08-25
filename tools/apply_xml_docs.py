#!/usr/bin/env python3
"""Insert XML documentation comments into the library from a curated table.

Every summary in docs_data.py was written by hand. Parameter descriptions come
from a vocabulary keyed by parameter name, which works because the codebase uses
the same names for the same things throughout.

The script refuses to invent text: a declaration with no entry in the table is
reported and left alone, so a missing summary is visible rather than filled with
something generic.

Usage:
    python3 tools/apply_xml_docs.py [--check]
"""

from __future__ import annotations

import argparse
import glob
import os
import re
import sys

DECL = re.compile(
    r"^(?P<indent>[ ]+)(?P<decl>(?:public|protected|internal)?[ ]*"
    r"(?:static |readonly |abstract |virtual |override |sealed |const |partial )*"
    r"(?P<ret>[\w<>?\[\], ]+?)[ ]+(?P<name>[A-Za-z_]\w*)[ ]*(?:\r?\n[ ]*)?(?P<tail>\(|\{|=>|;|=))",
    re.M)

TYPE_DECL = re.compile(
    r"^(?P<indent>[ ]*)(?:public |internal )?(?:sealed |abstract |static |partial )*"
    r"(?P<kind>class|interface|record|struct)[ ]+(?P<name>[A-Za-z_]\w*)", re.M)


def params(signature: str) -> list[tuple[str, str]]:
    """Return (type, name) for each parameter of a signature such as '(int a)'."""
    inner = signature[signature.index("(") + 1:signature.rindex(")")]
    out = []
    depth = 0
    current = ""
    for ch in inner:
        if ch in "<([":
            depth += 1
        elif ch in ">)]":
            depth -= 1
        if ch == "," and depth == 0:
            out.append(current)
            current = ""
        else:
            current += ch
    if current.strip():
        out.append(current)
    result = []
    for piece in out:
        piece = piece.strip()
        if not piece:
            continue
        typ, name = piece.rsplit(" ", 1)
        result.append((typ.strip(), name.strip()))
    return result


def signature_of(text: str, start: int) -> str:
    """The full parameter list starting at the opening parenthesis."""
    depth = 0
    for i in range(start, len(text)):
        if text[i] == "(":
            depth += 1
        elif text[i] == ")":
            depth -= 1
            if depth == 0:
                return text[start:i + 1]
    raise ValueError("unbalanced parentheses")


def build_block(indent: str, summary: str, args: list[tuple[str, str]],
                returns: str | None, vocabulary: dict[str, str]) -> str:
    lines = [f"{indent}/// <summary>", f"{indent}/// {summary}", f"{indent}/// </summary>"]
    for typ, name in args:
        description = vocabulary.get(name)
        if description is None:
            raise KeyError(f"no vocabulary entry for parameter '{name}'")
        lines.append(f'{indent}/// <param name="{name}">{description}</param>')
    if returns:
        lines.append(f"{indent}/// <returns>{returns}</returns>")
    return "\n".join(lines) + "\n"


def process(path: str, table: dict, vocabulary: dict[str, str],
            missing: list[str]) -> str:
    rel = path.split("DotnetDesignPatterns/", 1)[-1]
    entries = table.get(rel, {})
    text = open(path, encoding="utf-8-sig").read()
    is_interface_file = bool(re.search(r"^\s*public interface", text, re.M))

    # Types first, walking backwards so earlier offsets stay valid.
    insertions = []
    for m in TYPE_DECL.finditer(text):
        if "///" in text[max(0, m.start() - 200):m.start()]:
            continue
        summary = entries.get("@type")
        if summary is None:
            missing.append(f"{rel}: type {m.group('name')}")
            continue
        insertions.append((m.start(), build_block(m.group("indent"), summary, [], None,
                                                  vocabulary)))

    for m in DECL.finditer(text):
        decl, name, tail, indent = m.group("decl"), m.group("name"), m.group("tail"), m.group("indent")
        if len(indent) != 8:
            continue
        if not (decl.lstrip().startswith(("public", "protected")) or is_interface_file):
            continue
        if decl.lstrip().startswith("private"):
            continue
        before = text[max(0, m.start() - 400):m.start()]
        if before.rstrip().endswith("</returns>") or before.rstrip().endswith("</summary>") \
                or before.rstrip().endswith("</param>"):
            continue
        args: list[tuple[str, str]] = []
        if tail == "(":
            sig = signature_of(text, text.index("(", m.start("name")))
            args = params(sig)
        key = name
        if args and f"{name}#{args[0][0]}" in entries:
            key = f"{name}#{args[0][0]}"
        elif f"{name}#" in entries and not args:
            key = f"{name}#"
        entry = entries.get(key)
        if entry is None:
            missing.append(f"{rel}: {name}")
            continue
        summary, returns = (entry if isinstance(entry, tuple) else (entry, None))
        insertions.append((m.start(), build_block(indent, summary, args, returns, vocabulary)))

    for pos, block in sorted(insertions, reverse=True):
        text = text[:pos] + block + text[pos:]
    return text


def main(argv) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--check", action="store_true")
    args = parser.parse_args(list(argv))

    here = os.path.dirname(os.path.abspath(__file__))
    sys.path.insert(0, here)
    from docs_data import DOCS, PARAMETERS  # noqa: E402

    root = os.path.join(os.path.dirname(here), "src", "DotnetDesignPatterns")
    missing: list[str] = []
    written = 0
    for path in sorted(glob.glob(os.path.join(root, "**", "*.cs"), recursive=True)):
        updated = process(path, DOCS, PARAMETERS, missing)
        if updated != open(path, encoding="utf-8-sig").read():
            if not args.check:
                with open(path, "w", encoding="utf-8-sig", newline="\n") as fh:
                    fh.write(updated)
            written += 1

    if missing:
        print(f"{len(missing)} declarations have no entry in the table:")
        for m in missing:
            print("  " + m)
        return 1
    print(f"documentation applied to {written} files" if not args.check
          else f"{written} files would change")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
