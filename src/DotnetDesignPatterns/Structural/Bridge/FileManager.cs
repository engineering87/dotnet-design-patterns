// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Bridge
{
    /// <summary>
    /// The abstraction side of the bridge. It delegates every operation to an IFileSystem, so the two hierarchies evolve separately.
    /// </summary>
    public abstract class FileManager
    {
        /// <summary>
        /// The implementation this abstraction delegates to.
        /// </summary>
        protected readonly IFileSystem _fileSystem;

        /// <summary>
        /// Binds the abstraction to an implementation.
        /// </summary>
        /// <param name="fileSystem">The file system implementation to write through.</param>
        protected FileManager(IFileSystem fileSystem)
        {
            ArgumentNullException.ThrowIfNull(fileSystem);

            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Saves the content under the given name.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="content">The content to write.</param>
        public abstract void SaveFile(string fileName, string content);

        /// <summary>
        /// Reads the named file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The content of the file.</returns>
        public abstract string ReadFile(string fileName);
    }
}
