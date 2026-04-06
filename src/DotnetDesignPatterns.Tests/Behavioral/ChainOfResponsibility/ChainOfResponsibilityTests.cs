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
            var handler = new ValidationHandler();

            // Act
            var output = CaptureConsoleOutput(() => handler.HandleRequest("read", "test.txt"));

            // Assert
            Assert.Contains("[VALIDATION]", output);
            Assert.Contains("read", output);
            Assert.Contains("test.txt", output);
        }

        [Fact]
        public void AuthorizationHandler_HandleRequest_ShouldCheckPermissions()
        {
            // Arrange
            var handler = new AuthorizationHandler();

            // Act
            var output = CaptureConsoleOutput(() => handler.HandleRequest("read", "test.txt"));

            // Assert
            Assert.Contains("[AUTHORIZATION]", output);
            Assert.Contains("read", output);
            Assert.Contains("test.txt", output);
        }

        [Fact]
        public void AuthorizationHandler_HandleRequest_DeleteOperation_ShouldDenyPermission()
        {
            // Arrange
            var handler = new AuthorizationHandler();

            // Act
            var output = CaptureConsoleOutput(() => handler.HandleRequest("delete", "test.txt"));

            // Assert
            Assert.Contains("Permission denied", output);
        }

        [Fact]
        public void LoggingHandler_HandleRequest_ShouldLogOperation()
        {
            // Arrange
            var handler = new LoggingHandler();

            // Act
            var output = CaptureConsoleOutput(() => handler.HandleRequest("write", "document.pdf"));

            // Assert
            Assert.Contains("[LOG]", output);
            Assert.Contains("write", output);
            Assert.Contains("document.pdf", output);
        }

        [Fact]
        public void ChainOfHandlers_ShouldProcessInOrder()
        {
            // Arrange
            var validationHandler = new ValidationHandler();
            var authorizationHandler = new AuthorizationHandler();
            var loggingHandler = new LoggingHandler();

            validationHandler.SetNext(authorizationHandler);
            authorizationHandler.SetNext(loggingHandler);

            // Act
            var output = CaptureConsoleOutput(() => validationHandler.HandleRequest("read", "test.txt"));

            // Assert
            Assert.Contains("[VALIDATION]", output);
            Assert.Contains("[AUTHORIZATION]", output);
            Assert.Contains("[LOG]", output);
        }

        [Fact]
        public void ChainOfHandlers_DeleteOperation_ShouldStopAtAuthorization()
        {
            // Arrange
            var validationHandler = new ValidationHandler();
            var authorizationHandler = new AuthorizationHandler();
            var loggingHandler = new LoggingHandler();

            validationHandler.SetNext(authorizationHandler);
            authorizationHandler.SetNext(loggingHandler);

            // Act
            var output = CaptureConsoleOutput(() => validationHandler.HandleRequest("delete", "test.txt"));

            // Assert
            Assert.Contains("[VALIDATION]", output);
            Assert.Contains("[AUTHORIZATION]", output);
            Assert.Contains("Permission denied", output);
            Assert.DoesNotContain("[LOG]", output);
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
