// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Creational.Builder;

namespace DotnetDesignPatterns.Tests.Creational.Builder
{
    public class BuilderTests
    {
        [Fact]
        public void Build_ShouldReturnConfiguredOperatingSystemConfig()
        {
            // Arrange
            var builder = new OperatingSystemConfigBuilder();
            string osName = "Linux";
            string version = "Ubuntu 22.04";
            string fileSystem = "ext4";
            bool firewallEnabled = true;
            string networkSettings = "DHCP";

            // Act
            var config = builder
                .SetOSName(osName)
                .SetVersion(version)
                .SetFileSystem(fileSystem)
                .EnableFirewall(firewallEnabled)
                .SetNetworkSettings(networkSettings)
                .Build();

            // Assert
            Assert.NotNull(config);
            Assert.Equal(osName, config.OSName);
            Assert.Equal(version, config.Version);
            Assert.Equal(fileSystem, config.FileSystem);
            Assert.Equal(firewallEnabled, config.IsFirewallEnabled);
            Assert.Equal(networkSettings, config.NetworkSettings);
        }

        [Fact]
        public void DefaultBuild_ShouldReturnEmptyOperatingSystemConfig()
        {
            // Arrange
            var builder = new OperatingSystemConfigBuilder();

            // Act
            var config = builder.Build();

            // Assert
            Assert.NotNull(config);
            Assert.Null(config.OSName);
            Assert.Null(config.Version);
            Assert.Null(config.FileSystem);
            Assert.False(config.IsFirewallEnabled);
            Assert.Null(config.NetworkSettings);
        }
    }
}
