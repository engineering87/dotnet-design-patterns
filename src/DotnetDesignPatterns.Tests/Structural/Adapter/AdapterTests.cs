// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Structural.Adapter;

namespace DotnetDesignPatterns.Tests.Structural.Adapter
{
    public class AdapterTests
    {
        [Fact]
        public void WindowsAdapter_GetSystemDetails_ShouldReturnWindowsInfo()
        {
            // Arrange
            var windowsOS = new WindowsOS();
            var adapter = new WindowsAdapter(windowsOS);

            // Act
            var result = adapter.GetSystemDetails();

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Windows", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void LinuxAdapter_GetSystemDetails_ShouldReturnLinuxInfo()
        {
            // Arrange
            var linuxOS = new LinuxOS();
            var adapter = new LinuxAdapter(linuxOS);

            // Act
            var result = adapter.GetSystemDetails();

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Ubuntu", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void WindowsAdapter_ImplementsISystemInfo()
        {
            // Arrange
            var windowsOS = new WindowsOS();
            var adapter = new WindowsAdapter(windowsOS);

            // Assert
            Assert.IsAssignableFrom<ISystemInfo>(adapter);
        }

        [Fact]
        public void LinuxAdapter_ImplementsISystemInfo()
        {
            // Arrange
            var linuxOS = new LinuxOS();
            var adapter = new LinuxAdapter(linuxOS);

            // Assert
            Assert.IsAssignableFrom<ISystemInfo>(adapter);
        }

        [Fact]
        public void Adapters_CanBeUsedInterchangeably()
        {
            // Arrange
            var adapters = new List<ISystemInfo>
            {
                new WindowsAdapter(new WindowsOS()),
                new LinuxAdapter(new LinuxOS())
            };

            // Act & Assert
            foreach (var adapter in adapters)
            {
                var result = adapter.GetSystemDetails();
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
    }
}
