// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using System.IO.Compression;

namespace DotnetDesignPatterns.Behavioral.Strategy
{
    // Concrete Strategy 1: ZIP Compression
    public class ZipCompressionStrategy : ICompressionStrategy
    {
        public void Compress(string filePath)
        {
            var outputFilePath = filePath + ".zip";
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var zipArchive = new FileStream(outputFilePath, FileMode.Create))
            using (var zipStream = new GZipStream(zipArchive, CompressionMode.Compress))
            {
                fileStream.CopyTo(zipStream);
            }
            Console.WriteLine($"File compressed to ZIP: {outputFilePath}");
        }
    }
}
