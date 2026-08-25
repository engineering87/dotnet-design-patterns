// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Bridge
{
    /// <summary>
    /// A refined abstraction that treats the content as text.
    /// </summary>
    public class TextFileManager : FileManager
    {
        /// <summary>
        /// Binds this manager to an implementation.
        /// </summary>
        /// <param name="fileSystem">The file system implementation to write through.</param>
        public TextFileManager(IFileSystem fileSystem) : base(fileSystem)
        {
        }

        /// <summary>
        /// Saves the text content under the given name.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="content">The content to write.</param>
        public override void SaveFile(string fileName, string content)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
            ArgumentNullException.ThrowIfNull(content);

            _fileSystem.WriteToFile(fileName, content);
        }

        /// <summary>
        /// Reads the named text file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The content of the file.</returns>
        public override string ReadFile(string fileName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

            return _fileSystem.ReadFromFile(fileName);
        }
    }
}
