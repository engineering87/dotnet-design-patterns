// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.AbstractFactory
{
    /// <summary>
    /// Creates one coherent family of operating system products.
    /// </summary>
    public interface IOperatingSystemFactory
    {
        /// <summary>
        /// Creates the product belonging to this family.
        /// </summary>
        /// <returns>A product of the family this factory represents.</returns>
        IOperatingSystem CreateOperatingSystem();
    }
}
