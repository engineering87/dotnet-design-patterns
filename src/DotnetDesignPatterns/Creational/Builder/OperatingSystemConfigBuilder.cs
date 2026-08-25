// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Builder
{
    /// <summary>
    /// The concrete builder. It holds one configuration and fills it in as the steps are called.
    /// </summary>
    public class OperatingSystemConfigBuilder : IOperatingSystemConfigBuilder
    {
        private readonly OperatingSystemConfig _config;

        /// <summary>
        /// Starts a new, empty configuration.
        /// </summary>
        public OperatingSystemConfigBuilder()
        {
            _config = new OperatingSystemConfig();
        }

        /// <summary>
        /// Records the name of the operating system.
        /// </summary>
        /// <param name="osName">The name of the operating system.</param>
        /// <returns>The same builder.</returns>
        public IOperatingSystemConfigBuilder SetOSName(string osName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(osName);

            _config.OSName = osName;
            return this;
        }

        /// <summary>
        /// Records the version string.
        /// </summary>
        /// <param name="version">The version string of the operating system.</param>
        /// <returns>The same builder.</returns>
        public IOperatingSystemConfigBuilder SetVersion(string version)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(version);

            _config.Version = version;
            return this;
        }

        /// <summary>
        /// Records the file system.
        /// </summary>
        /// <param name="fileSystem">The file system implementation to write through.</param>
        /// <returns>The same builder.</returns>
        public IOperatingSystemConfigBuilder SetFileSystem(string fileSystem)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileSystem);

            _config.FileSystem = fileSystem;
            return this;
        }

        /// <summary>
        /// Turns the firewall on or off.
        /// </summary>
        /// <param name="enable">True to enable the firewall, false to leave it off.</param>
        /// <returns>The same builder.</returns>
        public IOperatingSystemConfigBuilder EnableFirewall(bool enable)
        {
            _config.IsFirewallEnabled = enable;
            return this;
        }

        /// <summary>
        /// Records the network configuration.
        /// </summary>
        /// <param name="networkSettings">The network configuration to record.</param>
        /// <returns>The same builder.</returns>
        public IOperatingSystemConfigBuilder SetNetworkSettings(string networkSettings)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(networkSettings);

            _config.NetworkSettings = networkSettings;
            return this;
        }

        /// <summary>
        /// Hands over the configuration assembled so far.
        /// </summary>
        /// <returns>The configuration built by the preceding calls.</returns>
        public OperatingSystemConfig Build()
        {
            return _config;
        }
    }
}
