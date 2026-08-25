// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Composite
{
    /// <summary>
    /// A branch of the tree. It answers the same calls as a leaf and forwards them to its children.
    /// </summary>
    public class Directory : FileSystemComponent
    {
        private readonly List<FileSystemComponent> _children = [];

        /// <summary>
        /// Creates an empty directory with the given name.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        public Directory(string name) : base(name)
        {
        }

        /// <summary>
        /// Adds a child component.
        /// </summary>
        /// <param name="component">The child component.</param>
        public void Add(FileSystemComponent component)
        {
            ArgumentNullException.ThrowIfNull(component);

            _children.Add(component);
        }

        /// <summary>
        /// Removes a child component.
        /// </summary>
        /// <param name="component">The child component.</param>
        public void Remove(FileSystemComponent component)
        {
            ArgumentNullException.ThrowIfNull(component);

            _children.Remove(component);
        }

        /// <summary>
        /// Writes the directory and everything under it.
        /// </summary>
        /// <param name="depth">The indentation depth used when printing the tree.</param>
        public override void Display(int depth)
        {
            Output.WriteLine(new string('-', depth) + Name);
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }

        /// <summary>
        /// Adds up the size of every child.
        /// </summary>
        /// <returns>The total size in bytes.</returns>
        public override long CalculateSize()
        {
            long totalSize = 0;
            foreach (var component in _children)
            {
                totalSize += component.CalculateSize();
            }
            return totalSize;
        }
    }
}
