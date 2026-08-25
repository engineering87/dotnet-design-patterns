// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Creational.AbstractFactory;

namespace DotnetDesignPatterns.Tests.Creational.AbstractFactory
{
    public class AbstractFactoryTests
    {
        [Fact]
        public void LinuxOSFactory_CreateOperatingSystem_ShouldReturnLinuxOS()
        {
            // Arrange
            IOperatingSystemFactory factory = new LinuxOSFactory();

            // Act
            var os = factory.CreateOperatingSystem();

            // Assert
            Assert.NotNull(os);
            Assert.IsType<LinuxOS>(os);
        }

        [Fact]
        public void WindowsOSFactory_CreateOperatingSystem_ShouldReturnWindowsOS()
        {
            // Arrange
            IOperatingSystemFactory factory = new WindowsOSFactory();

            // Act
            var os = factory.CreateOperatingSystem();

            // Assert
            Assert.NotNull(os);
            Assert.IsType<WindowsOS>(os);
        }

        [Fact]
        public void LinuxOS_DisplayInfo_ShouldOutputLinuxInfo()
        {
            // Arrange
            var output = new StringWriter();
            var factory = new LinuxOSFactory { Output = output };
            var os = factory.CreateOperatingSystem();

            // Act
            os.DisplayInfo();

            // Assert
            Assert.NotEmpty(output.ToString());
            Assert.Contains("Linux", output.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void WindowsOS_DisplayInfo_ShouldOutputWindowsInfo()
        {
            // Arrange
            var output = new StringWriter();
            var factory = new WindowsOSFactory { Output = output };
            var os = factory.CreateOperatingSystem();

            // Act
            os.DisplayInfo();

            // Assert
            Assert.NotEmpty(output.ToString());
            Assert.Contains("Windows", output.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void LinuxOS_Configure_ShouldNotThrowException()
        {
            // Arrange
            var factory = new LinuxOSFactory();
            var os = factory.CreateOperatingSystem();

            // Act & Assert
            var exception = Record.Exception(() => os.Configure());
            Assert.Null(exception);
        }

        [Fact]
        public void WindowsOS_Configure_ShouldNotThrowException()
        {
            // Arrange
            var factory = new WindowsOSFactory();
            var os = factory.CreateOperatingSystem();

            // Act & Assert
            var exception = Record.Exception(() => os.Configure());
            Assert.Null(exception);
        }

        [Fact]
        public void Factories_ShouldCreateDifferentOSTypes()
        {
            // Arrange
            var linuxFactory = new LinuxOSFactory();
            var windowsFactory = new WindowsOSFactory();

            // Act
            var linuxOs = linuxFactory.CreateOperatingSystem();
            var windowsOs = windowsFactory.CreateOperatingSystem();

            // Assert
            Assert.NotSame(linuxOs, windowsOs);
            Assert.IsType<LinuxOS>(linuxOs);
            Assert.IsType<WindowsOS>(windowsOs);
        }

    }
}
