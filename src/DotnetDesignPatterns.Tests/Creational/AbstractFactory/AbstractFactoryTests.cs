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
            var factory = new LinuxOSFactory();
            var os = factory.CreateOperatingSystem();

            // Act
            var output = CaptureConsoleOutput(() => os.DisplayInfo());

            // Assert
            Assert.NotNull(output);
            Assert.Contains("Linux", output, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void WindowsOS_DisplayInfo_ShouldOutputWindowsInfo()
        {
            // Arrange
            var factory = new WindowsOSFactory();
            var os = factory.CreateOperatingSystem();

            // Act
            var output = CaptureConsoleOutput(() => os.DisplayInfo());

            // Assert
            Assert.NotNull(output);
            Assert.Contains("Windows", output, StringComparison.OrdinalIgnoreCase);
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

        private static string CaptureConsoleOutput(Action action)
        {
            var originalOutput = Console.Out;
            try
            {
                using var stringWriter = new StringWriter();
                Console.SetOut(stringWriter);
                action.Invoke();
                return stringWriter.ToString();
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }
    }
}
