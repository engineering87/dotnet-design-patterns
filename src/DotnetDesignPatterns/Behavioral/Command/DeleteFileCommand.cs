// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    /// <summary>
    /// Captures a delete request.
    /// </summary>
    public class DeleteFileCommand : ICommand
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        private readonly FileSystemReceiver _fileSystem;
        private readonly string _filename;

        /// <summary>
        /// Binds the request to a receiver and a file name.
        /// </summary>
        /// <param name="fileSystem">The file system implementation to write through.</param>
        /// <param name="filename">The name of the file.</param>
        public DeleteFileCommand(FileSystemReceiver fileSystem, string filename)
        {
            ArgumentNullException.ThrowIfNull(fileSystem);
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            _fileSystem = fileSystem;
            _filename = filename;
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        public void Execute()
        {
            _fileSystem.DeleteFile(_filename);
        }

        /// <summary>
        /// Recreates the file that Execute deleted.
        /// </summary>
        public void Undo()
        {
            Output.WriteLine($"Undoing delete: Recreating file {_filename}");
            _fileSystem.CreateFile(_filename);  // Re-create the file (simple undo example)
        }
    }
}
