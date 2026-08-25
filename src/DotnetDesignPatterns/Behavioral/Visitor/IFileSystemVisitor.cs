// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    /// <summary>
    /// One operation over the whole element structure.
    /// </summary>
    public interface IFileSystemVisitor
    {
        /// <summary>
        /// Operates on a file.
        /// </summary>
        /// <param name="file">The file being visited.</param>
        void Visit(File file);

        /// <summary>
        /// Operates on a directory.
        /// </summary>
        /// <param name="directory">The directory being visited.</param>
        void Visit(Directory directory);
    }
}
