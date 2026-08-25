// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Strategy
{
    /// <summary>
    /// One interchangeable compression algorithm.
    /// </summary>
    public interface ICompressionStrategy
    {
        /// <summary>
        /// Compresses the file at the given path.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        void Compress(string filePath);
    }
}
