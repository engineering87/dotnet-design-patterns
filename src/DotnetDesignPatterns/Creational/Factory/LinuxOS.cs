// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)

namespace DotnetDesignPatterns.Creational.Factory
{
    /// <summary>
    /// The Linux product.
    /// </summary>
    public class LinuxOS : IOperatingSystem
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Applies the Linux configuration.
        /// </summary>
        public void Configure()
        {
            Output.WriteLine("Configuring Linux OS with ext4 file system and firewall enabled.");
        }

        /// <summary>
        /// Writes a short description of the Linux product.
        /// </summary>
        public void DisplayInfo()
        {
            Output.WriteLine("Operating System: Linux");
        }
    }
}
