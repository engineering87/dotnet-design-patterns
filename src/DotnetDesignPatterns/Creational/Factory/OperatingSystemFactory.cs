// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)

namespace DotnetDesignPatterns.Creational.Factory
{
    /// <summary>
    /// Creates an operating system without the caller naming a concrete type.
    /// </summary>
    public static class OperatingSystemFactory
    {
        /// <summary>
        /// Creates the operating system matching the requested type.
        /// </summary>
        /// <param name="osType">The requested operating system, either windows or linux.</param>
        /// <param name="output">Where the product writes its narration. Defaults to the console.</param>
        /// <returns>A product ready to be configured.</returns>
        public static IOperatingSystem CreateOperatingSystem(string osType, TextWriter? output = null)
        {
            ArgumentNullException.ThrowIfNull(osType);

            var sink = output ?? Console.Out;

            return osType.ToLower() switch
            {
                "linux" => new LinuxOS { Output = sink },
                "windows" => new WindowsOS { Output = sink },
                _ => throw new ArgumentException("Invalid OS Type", nameof(osType)),
            };
        }
    }
}
