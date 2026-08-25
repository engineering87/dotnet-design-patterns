// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Prototype
{
    /// <summary>
    /// Settings that are copied rather than rebuilt.
    /// </summary>
    public class OperatingSystemSettings : IPrototype<OperatingSystemSettings>
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// The name of the operating system.
        /// </summary>
        public string OSName { get; set; }

        /// <summary>
        /// The version string.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Creates the settings that later copies start from.
        /// </summary>
        /// <param name="osName">The name of the operating system.</param>
        /// <param name="version">The version string of the operating system.</param>
        public OperatingSystemSettings(string osName, string version)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(osName);
            ArgumentException.ThrowIfNullOrWhiteSpace(version);

            OSName = osName;
            Version = version;
        }

        // Returns a new instance that carries the same values as the current one.
        // Every field here is a string, and strings are immutable in .NET, so copying
        // the references is enough: the clone cannot observe a change made through the
        // original. A type holding mutable members would have to copy those members
        // explicitly in order to be a true deep copy.

        /// <summary>
        /// Produces a copy of these settings.
        /// </summary>
        /// <returns>A new instance with the same values.</returns>
        public OperatingSystemSettings Clone()
        {
            return new OperatingSystemSettings(OSName, Version) { Output = Output };
        }

        // Writes the operating system settings to the console.

        /// <summary>
        /// Writes the settings.
        /// </summary>
        public void DisplaySettings()
        {
            Output.WriteLine($"OS Name: {OSName}");
            Output.WriteLine($"Version: {Version}");
        }
    }
}
