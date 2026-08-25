// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Iterator
{
    /// <summary>
    /// An item a file system iterator can return.
    /// </summary>
    public interface IFileSystemElement
    {
        /// <summary>
        /// The name of the element.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Writes a short description of the element.
        /// </summary>
        void PrintDetails();
    }
}
