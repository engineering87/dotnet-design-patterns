// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    public class WriteFileCommand : ICommand
    {
        private readonly FileSystemReceiver _fileSystem;
        private readonly string _filename;
        private readonly string _content;

        public WriteFileCommand(FileSystemReceiver fileSystem, string filename, string content)
        {
            _fileSystem = fileSystem;
            _filename = filename;
            _content = content;
        }

        public void Execute()
        {
            _fileSystem.WriteFile(_filename, _content);
        }

        public void Undo()
        {
            Console.WriteLine($"Undoing write to file: {_filename}");
            _fileSystem.WriteFile(_filename, "");  // Clear the content (simple undo example)
        }
    }
}
