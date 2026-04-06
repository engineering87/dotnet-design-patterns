// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Flyweight
{
    // Flyweight Factory
    public class FileMetadataFactory
    {
        private readonly Dictionary<string, IFileMetadata> _metadataCache = new Dictionary<string, IFileMetadata>();
        private readonly object _lock = new object();

        public IFileMetadata GetFileMetadata(string fileType, string owner)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileType);
            ArgumentException.ThrowIfNullOrWhiteSpace(owner);

            string key = $"{fileType}:{owner}";

            lock (_lock)
            {
                if (!_metadataCache.TryGetValue(key, out var metadata))
                {
                    Console.WriteLine("Creating new file metadata.");
                    metadata = new FileMetadata(fileType, owner);
                    _metadataCache[key] = metadata;
                }
                else
                {
                    Console.WriteLine("Reusing existing file metadata.");
                }

                return metadata;
            }
        }

        public int CacheCount => _metadataCache.Count;
    }
}
