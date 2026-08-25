// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    /// <summary>
    /// Captures a write request.
    /// </summary>
    public class WriteFileCommand : ICommand
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        private readonly FileSystemReceiver _fileSystem;
        private readonly string _filename;
        private readonly string _content;

        /// <summary>
        /// Binds the request to a receiver, a file name, and its content.
        /// </summary>
        /// <param name="fileSystem">The file system implementation to write through.</param>
        /// <param name="filename">The name of the file.</param>
        /// <param name="content">The content to write.</param>
        public WriteFileCommand(FileSystemReceiver fileSystem, string filename, string content)
        {
            ArgumentNullException.ThrowIfNull(fileSystem);
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);
            ArgumentNullException.ThrowIfNull(content);

            _fileSystem = fileSystem;
            _filename = filename;
            _content = content;
        }

        /// <summary>
        /// Writes the content.
        /// </summary>
        public void Execute()
        {
            _fileSystem.WriteFile(_filename, _content);
        }

        /// <summary>
        /// Clears the content that Execute wrote.
        /// </summary>
        public void Undo()
        {
            Output.WriteLine($"Undoing write to file: {_filename}");
            _fileSystem.WriteFile(_filename, "");  // Clear the content (simple undo example)
        }
    }
}
