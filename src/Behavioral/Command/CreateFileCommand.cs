// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    // Concrete Command Classes
    public class CreateFileCommand : ICommand
    {
        private readonly FileSystemReceiver _fileSystem;
        private readonly string _filename;

        public CreateFileCommand(FileSystemReceiver fileSystem, string filename)
        {
            _fileSystem = fileSystem;
            _filename = filename;
        }

        public void Execute()
        {
            _fileSystem.CreateFile(_filename);
        }

        public void Undo()
        {
            _fileSystem.DeleteFile(_filename);
        }
    }
}
