# Contributing

Thank you for considering a contribution to this repository. It is a reference collection of the twenty-three Gang of Four design patterns written in C#, so the goal of every change is clarity first and cleverness never.

## Ways to contribute

- Fix a defect in a pattern implementation.
- Improve the explanation in a pattern README.
- Add a missing test case.
- Improve the example so that it demonstrates the pattern more directly.

New patterns outside the Gang of Four catalogue are out of scope. Open an issue first if you believe an exception is warranted.

## Getting started

```bash
git clone https://github.com/engineering87/dotnet-design-patterns.git
cd dotnet-design-patterns
dotnet build src/DotnetDesignPatterns.sln
dotnet test src/DotnetDesignPatterns.sln
```

`global.json` selects the Microsoft.Testing.Platform runner, which xUnit v3 uses natively. The VSTest options of `dotnet test`, `--logger` and `--collect` among them, do not apply. The platform has its own equivalents, documented under Microsoft.Testing.Platform extensions.

The solution targets .NET 10, the current long term support release. Install the .NET 10 SDK before building.

## Repository conventions

- One folder per pattern, under the folder of its category.
- Every pattern folder contains a `README.md` that starts with a level one heading naming the pattern.
- Every pattern is covered by a test class under `src/DotnetDesignPatterns.Tests`, mirroring the folder structure of the implementation.
- Code, comments, commit messages, and documentation are written in English.
- Nullable reference types are enabled. Do not silence a warning that points at a real gap.
- Formatting follows `.editorconfig`. Run `dotnet format src/DotnetDesignPatterns.sln` before opening a pull request. The build workflow checks this.

## Documentation and guards

Two conventions apply to every type in the library.

Every public and protected declaration carries an XML documentation comment. `GenerateDocumentationFile` is on, so a missing one shows up as CS1591 at build time. Write the summary as a sentence about what the member does for the caller, not a restatement of its name.

A class that narrates its work writes through `Output`, never through `Console` directly, and hands its own sink to any object it creates.

Every public entry point validates a reference argument it stores or dereferences: `ArgumentNullException.ThrowIfNull` for objects, `ArgumentException.ThrowIfNullOrWhiteSpace` for a string where an empty value is meaningless. Where an empty value is legitimate content, such as the text written to a file, only null is rejected. A few methods deliberately coerce instead of throwing; those carry a comment saying so.

## Diagrams

The UML diagram at the top of each pattern README is generated, not drawn by hand. The shapes live in `tools/diagram_specs.py` and the renderer is `tools/generate_diagrams.py`.

```bash
python3 tools/generate_diagrams.py           # rewrite docs/diagrams
python3 tools/generate_diagrams.py --check   # fail if a committed file is stale
```

`--check` also reads the C# sources and confirms that every class name and every member label in a diagram exists. A renamed method therefore breaks the build rather than leaving a diagram quietly wrong.

The XML documentation is applied the same way, from a table of hand written summaries in `tools/docs_data.py`:

```bash
python3 tools/apply_xml_docs.py              # insert any missing documentation
```

The script refuses to invent text. A declaration with no entry in the table is reported and left alone, so a gap is visible instead of being filled with something generic.

Edit the specification, regenerate, and commit both the specification and the SVG. The build workflow runs the check, so a diagram cannot drift away from the description it came from. Do not edit a file under `docs/diagrams` directly.

## Tests

A pattern counts as covered when a test can observe the collaboration, not only run it. Prefer asserting on return values and on state the participants expose.

Where an example narrates what it is doing, it writes to its `Output` property rather than to `Console` directly. The property defaults to `Console.Out`, so running the example still prints, and a test passes a `StringWriter` through the object initializer:

```csharp
var output = new StringWriter();
var handler = new ValidationHandler { Output = output };
```

Never call `Console.SetOut` in a test. It is process wide, it forces the whole suite to run serially, and the `Output` property exists so that nothing needs it.

## Commit messages

Commit messages follow the Conventional Commits format, in English, with an imperative subject of at most seventy-two characters.

```
fix: guard the observer list against concurrent notification
docs: add a heading to the behavioral pattern readme files
test: cover the mediator collaboration
```

## Pull requests

1. Fork the repository and create a branch from `main`.
2. Make the change, and add or update the tests that cover it.
3. Confirm that `dotnet build` and `dotnet test` both succeed.
4. Open the pull request and describe what changed and why.

The build workflow runs on every pull request. A pull request that does not build, or that leaves a test failing, cannot be merged.

## Reporting a defect

Open an issue and include the pattern involved, what you expected, what happened, and the version of the .NET SDK you used.
