// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Prototype
{
    /// <summary>
    /// A type that can produce a copy of itself.
    /// </summary>
    public interface IPrototype<T>
    {
        /// <summary>
        /// Produces a copy of this instance.
        /// </summary>
        /// <returns>A new instance carrying the same values.</returns>
        T Clone();
    }
}
