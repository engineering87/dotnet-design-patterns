// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Bridge
{
    /// <summary>
    /// The implementation side of the bridge. It varies independently of the abstraction that uses it.
    /// </summary>
    public interface IFileSystem
    {
        /// <summary>
        /// Writes the content to the named file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="content">The content to write.</param>
        void WriteToFile(string fileName, string content);

        /// <summary>
        /// Reads the named file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The content of the file.</returns>
        string ReadFromFile(string fileName);
    }
}
