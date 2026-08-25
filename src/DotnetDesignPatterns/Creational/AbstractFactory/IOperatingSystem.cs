// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.AbstractFactory
{
    /// <summary>
    /// The product of an operating system factory.
    /// </summary>
    public interface IOperatingSystem
    {
        /// <summary>
        /// Applies the configuration specific to this operating system.
        /// </summary>
        void Configure();

        /// <summary>
        /// Writes a short description of the operating system.
        /// </summary>
        void DisplayInfo();
    }
}
