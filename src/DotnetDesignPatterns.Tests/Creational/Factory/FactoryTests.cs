using DotnetDesignPatterns.Creational.Factory;

namespace DotnetDesignPatterns.Tests.Creational.Factory
{
    public class FactoryTests
    {
        [Fact]
        public void CreateOperatingSystem_ShouldReturnLinuxOS_WhenLinuxIsRequested()
        {
            // Act
            var os = OperatingSystemFactory.CreateOperatingSystem("linux");

            // Assert
            Assert.NotNull(os);
            Assert.IsType<LinuxOS>(os);
        }

        [Fact]
        public void CreateOperatingSystem_ShouldReturnWindowsOS_WhenWindowsIsRequested()
        {
            // Act
            var os = OperatingSystemFactory.CreateOperatingSystem("windows");

            // Assert
            Assert.NotNull(os);
            Assert.IsType<WindowsOS>(os);
        }

        [Fact]
        public void CreateOperatingSystem_ShouldThrowArgumentException_WhenInvalidOSTypeIsRequested()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => OperatingSystemFactory.CreateOperatingSystem("macos"));
        }
    }
}
