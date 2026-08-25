// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Concrete Element: Directory
    /// <summary>
    /// A directory element that a visitor can operate on.
    /// </summary>
    public class Directory : IFileSystemElement
    {
        /// <summary>
        /// The name of the directory.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The elements this directory holds.
        /// </summary>
        public List<IFileSystemElement> Elements { get; }

        /// <summary>
        /// Creates an empty directory with the given name.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        public Directory(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Name = name;
            Elements = new List<IFileSystemElement>();
        }

        /// <summary>
        /// Adds an element to the directory.
        /// </summary>
        /// <param name="element">The element to add to the collection.</param>
        public void AddElement(IFileSystemElement element)
        {
            ArgumentNullException.ThrowIfNull(element);

            Elements.Add(element);
        }

        /// <summary>
        /// Sends this directory to the visitor.
        /// </summary>
        /// <param name="visitor">The visitor that will operate on this element.</param>
        public void Accept(IFileSystemVisitor visitor)
        {
            ArgumentNullException.ThrowIfNull(visitor);

            visitor.Visit(this);
            foreach (var element in Elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
