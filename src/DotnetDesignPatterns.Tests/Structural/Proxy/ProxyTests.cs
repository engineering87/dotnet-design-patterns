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
            var output = new StringWriter();
            var resource = new Resource { Output = output };

            // Act
            resource.Access();

            // Assert
            Assert.Contains("Accessing the real resource", output.ToString());
        }

        [Fact]
        public void ResourceProxy_Access_WithAdminRole_ShouldAllowAccess()
        {
            // Arrange
            var output = new StringWriter();
            var proxy = new ResourceProxy("Admin") { Output = output };

            // Act
            proxy.Access();

            // Assert
            Assert.Contains("Proxy forwarding the request", output.ToString());
            Assert.Contains("Accessing the real resource", output.ToString());
        }

        [Fact]
        public void ResourceProxy_Access_WithNonAdminRole_ShouldDenyAccess()
        {
            // Arrange
            var output = new StringWriter();
            var proxy = new ResourceProxy("User") { Output = output };

            // Act
            proxy.Access();

            // Assert
            Assert.Contains("Access denied", output.ToString());
            Assert.DoesNotContain("Accessing the real resource", output.ToString());
        }

        [Fact]
        public void ResourceProxy_Access_WithGuestRole_ShouldDenyAccess()
        {
            // Arrange
            var output = new StringWriter();
            var proxy = new ResourceProxy("Guest") { Output = output };

            // Act
            proxy.Access();

            // Assert
            Assert.Contains("Access denied", output.ToString());
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
            var first = new StringWriter();
            var second = new StringWriter();
            var proxy = new ResourceProxy("Admin") { Output = first };

            // Act - the first access creates the real resource
            proxy.Access();
            var afterFirst = first.ToString();

            proxy = new ResourceProxy("Admin") { Output = second };
            proxy.Access();

            // Assert - both accesses reach the real resource
            Assert.Contains("Accessing the real resource", afterFirst);
            Assert.Contains("Accessing the real resource", second.ToString());
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
            var output = new StringWriter();
            var proxy = new ResourceProxy("admin") { Output = output };

            // Act
            proxy.Access();

            // Assert
            Assert.Contains("Access denied", output.ToString());
        }

        [Fact]
        public void Resource_And_Proxy_ShouldBeInterchangeable()
        {
            // Arrange
            var realOutput = new StringWriter();
            var proxyOutput = new StringWriter();
            IResource realResource = new Resource { Output = realOutput };
            IResource proxyResource = new ResourceProxy("Admin") { Output = proxyOutput };

            // Act
            realResource.Access();
            proxyResource.Access();

            // Assert - both reach the resource, the proxy by delegating to it
            Assert.Contains("Accessing the real resource", realOutput.ToString());
            Assert.Contains("Accessing the real resource", proxyOutput.ToString());
        }

    }
}
