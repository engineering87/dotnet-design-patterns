// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Flyweight
{
    /// <summary>
    /// Hands out flyweights, creating one per distinct key and returning the same instance for every later request.
    /// </summary>
    public class FileMetadataFactory
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        private readonly Dictionary<string, IFileMetadata> _metadataCache = new();
        private readonly object _lock = new();

        /// <summary>
        /// Returns the metadata for this type and owner, creating it once.
        /// </summary>
        /// <param name="fileType">The extension shared by the files that use this metadata.</param>
        /// <param name="owner">The owner shared by the files that use this metadata.</param>
        /// <returns>The shared instance for the key.</returns>
        public IFileMetadata GetFileMetadata(string fileType, string owner)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileType);
            ArgumentException.ThrowIfNullOrWhiteSpace(owner);

            string key = $"{fileType}:{owner}";

            lock (_lock)
            {
                if (!_metadataCache.TryGetValue(key, out var metadata))
                {
                    Output.WriteLine("Creating new file metadata.");
                    metadata = new FileMetadata(fileType, owner) { Output = Output };
                    _metadataCache[key] = metadata;
                }
                else
                {
                    Output.WriteLine("Reusing existing file metadata.");
                }

                return metadata;
            }
        }

        // The count is read under the same lock that guards the dictionary.
        // Dictionary<TKey, TValue> does not support a read concurrent with a write,
        // so reading Count outside the lock would be a race condition.
        /// <summary>
        /// How many distinct flyweights have been created.
        /// </summary>
        public int CacheCount
        {
            get
            {
                lock (_lock)
                {
                    return _metadataCache.Count;
                }
            }
        }
    }
}
