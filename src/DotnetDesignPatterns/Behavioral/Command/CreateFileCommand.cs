// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    /// <summary>
    /// Captures a create request.
    /// </summary>
    public class CreateFileCommand : ICommand
    {
        private readonly FileSystemReceiver _fileSystem;
        private readonly string _filename;

        /// <summary>
        /// Binds the request to a receiver and a file name.
        /// </summary>
        /// <param name="fileSystem">The file system implementation to write through.</param>
        /// <param name="filename">The name of the file.</param>
        public CreateFileCommand(FileSystemReceiver fileSystem, string filename)
        {
            ArgumentNullException.ThrowIfNull(fileSystem);
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            _fileSystem = fileSystem;
            _filename = filename;
        }

        /// <summary>
        /// Creates the file.
        /// </summary>
        public void Execute()
        {
            _fileSystem.CreateFile(_filename);
        }

        /// <summary>
        /// Deletes the file that Execute created.
        /// </summary>
        public void Undo()
        {
            _fileSystem.DeleteFile(_filename);
        }
    }
}
