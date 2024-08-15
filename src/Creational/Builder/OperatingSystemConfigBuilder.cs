// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Builder
{
    public class OperatingSystemConfigBuilder : IOperatingSystemConfigBuilder
    {
        private readonly OperatingSystemConfig _config;

        public OperatingSystemConfigBuilder()
        {
            _config = new OperatingSystemConfig();
        }

        public IOperatingSystemConfigBuilder SetOSName(string osName)
        {
            _config.OSName = osName;
            return this;
        }

        public IOperatingSystemConfigBuilder SetVersion(string version)
        {
            _config.Version = version;
            return this;
        }

        public IOperatingSystemConfigBuilder SetFileSystem(string fileSystem)
        {
            _config.FileSystem = fileSystem;
            return this;
        }

        public IOperatingSystemConfigBuilder EnableFirewall(bool enable)
        {
            _config.IsFirewallEnabled = enable;
            return this;
        }

        public IOperatingSystemConfigBuilder SetNetworkSettings(string networkSettings)
        {
            _config.NetworkSettings = networkSettings;
            return this;
        }

        public OperatingSystemConfig Build()
        {
            return _config;
        }
    }
}
