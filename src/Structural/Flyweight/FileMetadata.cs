// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Flyweight
{
    // Concrete Flyweight
    public class FileMetadata : IFileMetadata
    {
        private string _fileType;
        private string _owner;

        public FileMetadata(string fileType, string owner)
        {
            _fileType = fileType;
            _owner = owner;
        }

        public void DisplayFileInfo()
        {
            Console.WriteLine($"File Type: {_fileType}, Owner: {_owner}");
        }
    }
}
