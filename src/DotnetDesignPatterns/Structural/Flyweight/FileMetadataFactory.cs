// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Flyweight
{
    // Flyweight Factory
    public class FileMetadataFactory
    {
        private Dictionary<string, IFileMetadata> _metadataCache = new Dictionary<string, IFileMetadata>();

        public IFileMetadata GetFileMetadata(string fileType, string owner)
        {
            string key = $"{fileType}:{owner}";

            if (!_metadataCache.ContainsKey(key))
            {
                Console.WriteLine("Creating new file metadata.");
                _metadataCache[key] = new FileMetadata(fileType, owner);
            }
            else
            {
                Console.WriteLine("Reusing existing file metadata.");
            }

            return _metadataCache[key];
        }
    }
}
