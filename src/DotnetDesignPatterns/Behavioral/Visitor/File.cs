// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Concrete Element: File
    /// <summary>
    /// A file element that a visitor can operate on.
    /// </summary>
    public class File : IFileSystemElement
    {
        /// <summary>
        /// The name of the file.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Creates a file of the given size.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="size">The size of the file in bytes.</param>
        public File(string name, long size)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Name = name;
            Size = size;
        }

        /// <summary>
        /// Sends this file to the visitor.
        /// </summary>
        /// <param name="visitor">The visitor that will operate on this element.</param>
        public void Accept(IFileSystemVisitor visitor)
        {
            ArgumentNullException.ThrowIfNull(visitor);

            visitor.Visit(this);
        }
    }
}
