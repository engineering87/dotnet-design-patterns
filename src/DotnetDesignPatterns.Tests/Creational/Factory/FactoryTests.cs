// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
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

        [Fact]
        public void CreateOperatingSystem_ShouldThrowArgumentNullException_WhenOSTypeIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => OperatingSystemFactory.CreateOperatingSystem(null!));
        }

        [Fact]
        public void CreateOperatingSystem_ShouldBeCaseInsensitive()
        {
            // Act
            var linux1 = OperatingSystemFactory.CreateOperatingSystem("LINUX");
            var linux2 = OperatingSystemFactory.CreateOperatingSystem("Linux");
            var windows1 = OperatingSystemFactory.CreateOperatingSystem("WINDOWS");
            var windows2 = OperatingSystemFactory.CreateOperatingSystem("Windows");

            // Assert
            Assert.IsType<LinuxOS>(linux1);
            Assert.IsType<LinuxOS>(linux2);
            Assert.IsType<WindowsOS>(windows1);
            Assert.IsType<WindowsOS>(windows2);
        }
    }
}
