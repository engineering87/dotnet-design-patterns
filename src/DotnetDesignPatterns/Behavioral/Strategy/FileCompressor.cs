// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Strategy
{
    // Context: File Compressor
    /// <summary>
    /// The context. It compresses through whichever strategy is set, and can swap that strategy at run time.
    /// </summary>
    public class FileCompressor
    {
        private ICompressionStrategy? _compressionStrategy;

        /// <summary>
        /// Chooses the algorithm used from now on.
        /// </summary>
        /// <param name="compressionStrategy">The compression algorithm to use from now on.</param>
        public void SetCompressionStrategy(ICompressionStrategy compressionStrategy)
        {
            ArgumentNullException.ThrowIfNull(compressionStrategy);
            _compressionStrategy = compressionStrategy;
        }

        /// <summary>
        /// Compresses the file with the current strategy.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        public void CompressFile(string filePath)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

            if (_compressionStrategy == null)
            {
                throw new InvalidOperationException("Compression strategy is not set.");
            }
            _compressionStrategy.Compress(filePath);
        }
    }
}
