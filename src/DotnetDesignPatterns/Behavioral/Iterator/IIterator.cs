// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Iterator
{
    /// <summary>
    /// Walks a collection without exposing how the collection stores its items.
    /// </summary>
    public interface IIterator<T>
    {
        /// <summary>
        /// Reports whether anything is left.
        /// </summary>
        /// <returns>True when Next can be called.</returns>
        bool HasNext();

        /// <summary>
        /// Moves to the next item.
        /// </summary>
        /// <returns>The next item in the collection.</returns>
        T Next();
    }

}
