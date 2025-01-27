// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    public class DeleteFileCommand : ICommand
    {
        private readonly FileSystemReceiver _fileSystem;
        private readonly string _filename;

        public DeleteFileCommand(FileSystemReceiver fileSystem, string filename)
        {
            _fileSystem = fileSystem;
            _filename = filename;
        }

        public void Execute()
        {
            _fileSystem.DeleteFile(_filename);
        }

        public void Undo()
        {
            Console.WriteLine($"Undoing delete: Recreating file {_filename}");
            _fileSystem.CreateFile(_filename);  // Re-create the file (simple undo example)
        }
    }
}
