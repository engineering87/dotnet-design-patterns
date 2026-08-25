// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using System.IO.Compression;

namespace DotnetDesignPatterns.Behavioral.Strategy
{
    // Concrete Strategy 2: GZip Compression
    /// <summary>
    /// Compresses using the gzip format.
    /// </summary>
    public class GZipCompressionStrategy : ICompressionStrategy
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Compresses the file with gzip.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        public void Compress(string filePath)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

            var outputFilePath = filePath + ".gz";
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var gzipStream = new FileStream(outputFilePath, FileMode.Create))
            using (var compressionStream = new GZipStream(gzipStream, CompressionMode.Compress))
            {
                fileStream.CopyTo(compressionStream);
            }
            Output.WriteLine($"File compressed to GZIP: {outputFilePath}");
        }
    }
}
