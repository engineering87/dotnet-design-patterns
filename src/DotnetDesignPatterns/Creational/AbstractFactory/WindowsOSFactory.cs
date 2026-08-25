// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.AbstractFactory
{
    /// <summary>
    /// Produces the Windows family of products.
    /// </summary>
    public class WindowsOSFactory : IOperatingSystemFactory
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Creates the Windows product.
        /// </summary>
        /// <returns>A configured Windows product.</returns>
        public IOperatingSystem CreateOperatingSystem()
        {
            return new WindowsOS { Output = Output };
        }
    }
}
