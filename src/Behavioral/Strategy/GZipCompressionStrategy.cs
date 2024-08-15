// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using System.IO.Compression;

namespace DotnetDesignPatterns.Behavioral.Strategy
{
    // Concrete Strategy 2: GZip Compression
    public class GZipCompressionStrategy : ICompressionStrategy
    {
        public void Compress(string filePath)
        {
            var outputFilePath = filePath + ".gz";
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var gzipStream = new FileStream(outputFilePath, FileMode.Create))
            using (var compressionStream = new GZipStream(gzipStream, CompressionMode.Compress))
            {
                fileStream.CopyTo(compressionStream);
            }
            Console.WriteLine($"File compressed to GZIP: {outputFilePath}");
        }
    }
}
