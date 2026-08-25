// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.AbstractFactory
{
    /// <summary>
    /// Produces the Linux family of products.
    /// </summary>
    public class LinuxOSFactory : IOperatingSystemFactory
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Creates the Linux product.
        /// </summary>
        /// <returns>A configured Linux product.</returns>
        public IOperatingSystem CreateOperatingSystem()
        {
            return new LinuxOS { Output = Output };
        }
    }
}
