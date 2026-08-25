// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Composite
{
    /// <summary>
    /// A leaf of the tree. It has a size of its own and no children.
    /// </summary>
    public class File : FileSystemComponent
    {
        private long _size; // Size of the file in bytes

        /// <summary>
        /// Creates a file of the given size.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="size">The size of the file in bytes.</param>
        public File(string name, long size) : base(name)
        {
            _size = size;
        }

        /// <summary>
        /// Writes the file name, indented by the given depth.
        /// </summary>
        /// <param name="depth">The indentation depth used when printing the tree.</param>
        public override void Display(int depth)
        {
            Output.WriteLine(new string('-', depth) + Name);
        }

        /// <summary>
        /// Reports the size of the file.
        /// </summary>
        /// <returns>The size in bytes.</returns>
        public override long CalculateSize()
        {
            return _size;
        }
    }
}
