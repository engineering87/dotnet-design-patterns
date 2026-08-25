// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.ChainOfResponsibility;

namespace DotnetDesignPatterns.Tests.Behavioral.ChainOfResponsibility
{
    public class ChainOfResponsibilityTests
    {
        [Fact]
        public void ValidationHandler_HandleRequest_ShouldLogValidation()
        {
            // Arrange
            var output = new StringWriter();
            var handler = new ValidationHandler { Output = output };

            // Act
            handler.HandleRequest("read", "test.txt");

            // Assert
            Assert.Contains("[VALIDATION]", output.ToString());
            Assert.Contains("read", output.ToString());
            Assert.Contains("test.txt", output.ToString());
        }

        [Fact]
        public void AuthorizationHandler_HandleRequest_ShouldCheckPermissions()
        {
            // Arrange
            var output = new StringWriter();
            var handler = new AuthorizationHandler { Output = output };

            // Act
            handler.HandleRequest("read", "test.txt");

            // Assert
            Assert.Contains("[AUTHORIZATION]", output.ToString());
            Assert.Contains("read", output.ToString());
            Assert.Contains("test.txt", output.ToString());
        }

        [Fact]
        public void AuthorizationHandler_HandleRequest_DeleteOperation_ShouldDenyPermission()
        {
            // Arrange
            var output = new StringWriter();
            var handler = new AuthorizationHandler { Output = output };

            // Act
            handler.HandleRequest("delete", "test.txt");

            // Assert
            Assert.Contains("Permission denied", output.ToString());
        }

        [Fact]
        public void LoggingHandler_HandleRequest_ShouldLogOperation()
        {
            // Arrange
            var output = new StringWriter();
            var handler = new LoggingHandler { Output = output };

            // Act
            handler.HandleRequest("write", "document.pdf");

            // Assert
            Assert.Contains("[LOG]", output.ToString());
            Assert.Contains("write", output.ToString());
            Assert.Contains("document.pdf", output.ToString());
        }

        [Fact]
        public void ChainOfHandlers_ShouldProcessInOrder()
        {
            // Arrange
            var output = new StringWriter();
            var validationHandler = new ValidationHandler { Output = output };
            var authorizationHandler = new AuthorizationHandler { Output = output };
            var loggingHandler = new LoggingHandler { Output = output };

            validationHandler.SetNext(authorizationHandler);
            authorizationHandler.SetNext(loggingHandler);

            // Act
            validationHandler.HandleRequest("read", "test.txt");

            // Assert
            Assert.Contains("[VALIDATION]", output.ToString());
            Assert.Contains("[AUTHORIZATION]", output.ToString());
            Assert.Contains("[LOG]", output.ToString());
        }

        [Fact]
        public void ChainOfHandlers_DeleteOperation_ShouldStopAtAuthorization()
        {
            // Arrange
            var output = new StringWriter();
            var validationHandler = new ValidationHandler { Output = output };
            var authorizationHandler = new AuthorizationHandler { Output = output };
            var loggingHandler = new LoggingHandler { Output = output };

            validationHandler.SetNext(authorizationHandler);
            authorizationHandler.SetNext(loggingHandler);

            // Act
            validationHandler.HandleRequest("delete", "test.txt");

            // Assert
            Assert.Contains("[VALIDATION]", output.ToString());
            Assert.Contains("[AUTHORIZATION]", output.ToString());
            Assert.Contains("Permission denied", output.ToString());
            Assert.DoesNotContain("[LOG]", output.ToString());
        }

        [Fact]
        public void Handler_WithoutNextHandler_ShouldNotThrowException()
        {
            // Arrange
            var handler = new ValidationHandler();

            // Act & Assert
            var exception = Record.Exception(() => handler.HandleRequest("read", "test.txt"));
            Assert.Null(exception);
        }

    }
}
