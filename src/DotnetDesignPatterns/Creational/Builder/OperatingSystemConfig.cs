// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Builder
{
    /// <summary>
    /// The product the builder assembles, one setting at a time.
    /// </summary>
    public class OperatingSystemConfig
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        // The builder fills these in one step at a time, so an instance is legitimately
        // incomplete between construction and the final Build call. The properties are
        // initialised to an empty string rather than left null so that a partially built
        // configuration is still safe to read and to print.

        /// <summary>
        /// The name of the operating system.
        /// </summary>
        public string OSName { get; set; } = string.Empty;

        /// <summary>
        /// The version string.
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// The file system the installation uses.
        /// </summary>
        public string FileSystem { get; set; } = string.Empty;

        /// <summary>
        /// Whether the firewall is turned on.
        /// </summary>
        public bool IsFirewallEnabled { get; set; }

        /// <summary>
        /// The network configuration.
        /// </summary>
        public string NetworkSettings { get; set; } = string.Empty;

        /// <summary>
        /// Writes the whole configuration.
        /// </summary>
        public void DisplayConfig()
        {
            Output.WriteLine($"Operating System: {OSName}");
            Output.WriteLine($"Version: {Version}");
            Output.WriteLine($"File System: {FileSystem}");
            Output.WriteLine($"Firewall Enabled: {IsFirewallEnabled}");
            Output.WriteLine($"Network Settings: {NetworkSettings}");
            Output.WriteLine();
        }
    }
}
