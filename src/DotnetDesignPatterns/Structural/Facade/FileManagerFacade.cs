// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)

namespace DotnetDesignPatterns.Structural.Facade
{
    /// <summary>
    /// One entry point in front of the validator, the reader, and the writer.
    /// </summary>
    public class FileManagerFacade
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        private FileReader? _fileReader;
        private FileWriter? _fileWriter;
        private FileValidator? _fileValidator;

        // The subsystem is built on first use rather than in the constructor, because an
        // init accessor runs after the constructor and the facade has to pass its own
        // sink down to the three classes it hides.
        private FileReader Reader => _fileReader ??= new FileReader { Output = Output };

        private FileWriter Writer => _fileWriter ??= new FileWriter { Output = Output };

        private FileValidator Validator => _fileValidator ??= new FileValidator { Output = Output };

        /// <summary>
        /// Validates the path, reads what is there, and writes the new content.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <param name="newContent">The content that replaces what the file holds.</param>
        public void ProcessFile(string filePath, string newContent)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
            ArgumentNullException.ThrowIfNull(newContent);

            if (Validator.Validate(filePath))
            {
                string content = Reader.ReadFile(filePath);
                Output.WriteLine($"Current content: {content}");
                Writer.WriteFile(filePath, newContent);
                Output.WriteLine("File processed successfully.");
            }
            else
            {
                Output.WriteLine("File validation failed.");
            }
        }
    }
}
