// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Iterator
{
    /// <summary>
    /// A collection that can hand out an iterator over itself.
    /// </summary>
    public interface IFileSystemCollection
    {
        /// <summary>
        /// Creates an iterator positioned before the first element.
        /// </summary>
        /// <returns>A fresh iterator over this collection.</returns>
        IIterator<IFileSystemElement> CreateIterator();
    }
}
