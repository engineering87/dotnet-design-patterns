// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using System.IO.Compression;

namespace DotnetDesignPatterns.Behavioral.Strategy
{
    // Concrete Strategy 1: ZIP Compression
    /// <summary>
    /// Compresses using the zip format.
    /// </summary>
    public class ZipCompressionStrategy : ICompressionStrategy
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Compresses the file as a zip archive.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        public void Compress(string filePath)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

            var outputFilePath = filePath + ".zip";
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var zipArchive = new FileStream(outputFilePath, FileMode.Create))
            using (var zipStream = new GZipStream(zipArchive, CompressionMode.Compress))
            {
                fileStream.CopyTo(zipStream);
            }
            Output.WriteLine($"File compressed to ZIP: {outputFilePath}");
        }
    }
}
