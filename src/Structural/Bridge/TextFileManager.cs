// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Bridge
{
    public class TextFileManager : FileManager
    {
        public TextFileManager(IFileSystem fileSystem) : base(fileSystem)
        {
        }

        public override void SaveFile(string fileName, string content)
        {
            _fileSystem.WriteToFile(fileName, content);
        }

        public override string ReadFile(string fileName)
        {
            return _fileSystem.ReadFromFile(fileName);
        }
    }
}
