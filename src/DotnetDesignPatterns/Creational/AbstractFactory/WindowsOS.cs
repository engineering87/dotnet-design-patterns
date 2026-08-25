// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.AbstractFactory
{
    /// <summary>
    /// The Windows member of the product family.
    /// </summary>
    public class WindowsOS : IOperatingSystem
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Applies the Windows configuration.
        /// </summary>
        public void Configure()
        {
            Output.WriteLine("Configuring Windows OS with NTFS file system and firewall enabled.");
        }

        /// <summary>
        /// Writes a short description of the Windows product.
        /// </summary>
        public void DisplayInfo()
        {
            Output.WriteLine("Operating System: Windows");
        }
    }
}
