// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Structural.Proxy;

namespace DotnetDesignPatterns.Tests.Structural.Proxy
{
    public class ProxyTests
    {
        [Fact]
        public void Resource_Access_ShouldOutputAccessMessage()
        {
            // Arrange
            var resource = new Resource();

            // Act
            var output = CaptureConsoleOutput(() => resource.Access());

            // Assert
            Assert.Contains("Accessing the real resource", output);
        }

        [Fact]
        public void ResourceProxy_Access_WithAdminRole_ShouldAllowAccess()
        {
            // Arrange
            var proxy = new ResourceProxy("Admin");

            // Act
            var output = CaptureConsoleOutput(() => proxy.Access());

            // Assert
            Assert.Contains("Proxy forwarding the request", output);
            Assert.Contains("Accessing the real resource", output);
        }

        [Fact]
        public void ResourceProxy_Access_WithNonAdminRole_ShouldDenyAccess()
        {
            // Arrange
            var proxy = new ResourceProxy("User");

            // Act
            var output = CaptureConsoleOutput(() => proxy.Access());

            // Assert
            Assert.Contains("Access denied", output);
            Assert.DoesNotContain("Accessing the real resource", output);
        }

        [Fact]
        public void ResourceProxy_Access_WithGuestRole_ShouldDenyAccess()
        {
            // Arrange
            var proxy = new ResourceProxy("Guest");

            // Act
            var output = CaptureConsoleOutput(() => proxy.Access());

            // Assert
            Assert.Contains("Access denied", output);
        }

        [Fact]
        public void ResourceProxy_ImplementsIResource()
        {
            // Arrange
            var proxy = new ResourceProxy("Admin");

            // Assert
            Assert.IsAssignableFrom<IResource>(proxy);
        }

        [Fact]
        public void ResourceProxy_LazyInitialization_ShouldCreateResourceOnFirstAccess()
        {
            // Arrange
            var proxy = new ResourceProxy("Admin");

            // Act - First access creates the real resource
            var output1 = CaptureConsoleOutput(() => proxy.Access());
            var output2 = CaptureConsoleOutput(() => proxy.Access());

            // Assert - Both accesses should work and access the real resource
            Assert.Contains("Accessing the real resource", output1);
            Assert.Contains("Accessing the real resource", output2);
        }

        [Fact]
        public void ResourceProxy_Access_MultipleCallsWithAdmin_ShouldSucceed()
        {
            // Arrange
            var proxy = new ResourceProxy("Admin");

            // Act
            var exception = Record.Exception(() =>
            {
                proxy.Access();
                proxy.Access();
                proxy.Access();
            });

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void ResourceProxy_Access_CaseSensitiveRole_ShouldDenyLowercaseAdmin()
        {
            // Arrange
            var proxy = new ResourceProxy("admin");

            // Act
            var output = CaptureConsoleOutput(() => proxy.Access());

            // Assert
            Assert.Contains("Access denied", output);
        }

        [Fact]
        public void Resource_And_Proxy_ShouldBeInterchangeable()
        {
            // Arrange
            IResource realResource = new Resource();
            IResource proxyResource = new ResourceProxy("Admin");

            // Act
            var realOutput = CaptureConsoleOutput(() => realResource.Access());
            var proxyOutput = CaptureConsoleOutput(() => proxyResource.Access());

            // Assert - Both should access the resource (proxy delegates to real)
            Assert.Contains("Accessing the real resource", realOutput);
            Assert.Contains("Accessing the real resource", proxyOutput);
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
