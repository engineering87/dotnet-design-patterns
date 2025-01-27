// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Bridge
{
    public abstract class FileManager
    {
        protected IFileSystem _fileSystem;

        protected FileManager(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public abstract void SaveFile(string fileName, string content);
        public abstract string ReadFile(string fileName);
    }
}
