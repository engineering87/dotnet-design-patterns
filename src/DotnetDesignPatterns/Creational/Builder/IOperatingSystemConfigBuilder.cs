// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Builder
{
    /// <summary>
    /// Assembles an operating system configuration step by step. Every step returns the builder, so the calls chain into one expression.
    /// </summary>
    public interface IOperatingSystemConfigBuilder
    {
        /// <summary>
        /// Records the name of the operating system.
        /// </summary>
        /// <param name="osName">The name of the operating system.</param>
        /// <returns>The same builder.</returns>
        IOperatingSystemConfigBuilder SetOSName(string osName);

        /// <summary>
        /// Records the version string.
        /// </summary>
        /// <param name="version">The version string of the operating system.</param>
        /// <returns>The same builder.</returns>
        IOperatingSystemConfigBuilder SetVersion(string version);

        /// <summary>
        /// Records the file system.
        /// </summary>
        /// <param name="fileSystem">The file system implementation to write through.</param>
        /// <returns>The same builder.</returns>
        IOperatingSystemConfigBuilder SetFileSystem(string fileSystem);

        /// <summary>
        /// Turns the firewall on or off.
        /// </summary>
        /// <param name="enable">True to enable the firewall, false to leave it off.</param>
        /// <returns>The same builder.</returns>
        IOperatingSystemConfigBuilder EnableFirewall(bool enable);

        /// <summary>
        /// Records the network configuration.
        /// </summary>
        /// <param name="networkSettings">The network configuration to record.</param>
        /// <returns>The same builder.</returns>
        IOperatingSystemConfigBuilder SetNetworkSettings(string networkSettings);

        /// <summary>
        /// Hands over the configuration assembled so far.
        /// </summary>
        /// <returns>The configuration built by the preceding calls.</returns>
        OperatingSystemConfig Build();
    }
}
