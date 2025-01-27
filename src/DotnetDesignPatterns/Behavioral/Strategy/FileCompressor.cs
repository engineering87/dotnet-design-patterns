// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Strategy
{
    // Context: File Compressor
    public class FileCompressor
    {
        private ICompressionStrategy _compressionStrategy;

        public void SetCompressionStrategy(ICompressionStrategy compressionStrategy)
        {
            _compressionStrategy = compressionStrategy;
        }

        public void CompressFile(string filePath)
        {
            if (_compressionStrategy == null)
            {
                throw new InvalidOperationException("Compression strategy is not set.");
            }
            _compressionStrategy.Compress(filePath);
        }
    }
}
