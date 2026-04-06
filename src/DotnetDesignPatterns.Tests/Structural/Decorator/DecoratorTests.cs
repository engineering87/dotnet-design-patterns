// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Structural.Decorator;

namespace DotnetDesignPatterns.Tests.Structural.Decorator
{
    public class DecoratorTests
    {
        [Fact]
        public void BasicNotification_Send_ShouldOutputMessage()
        {
            // Arrange
            var notification = new BasicNotification();

            // Act
            var output = CaptureConsoleOutput(() => notification.Send("Hello World"));

            // Assert
            Assert.Contains("Hello World", output);
            Assert.Contains("Sending notification", output);
        }

        [Fact]
        public void LoggingDecorator_Send_ShouldLogAndSendMessage()
        {
            // Arrange
            var basicNotification = new BasicNotification();
            var loggingDecorator = new LoggingDecorator(basicNotification);

            // Act
            var output = CaptureConsoleOutput(() => loggingDecorator.Send("Test Message"));

            // Assert
            Assert.Contains("Logging notification", output);
            Assert.Contains("Sending notification", output);
            Assert.Contains("Test Message", output);
        }

        [Fact]
        public void EncryptionDecorator_Send_ShouldEncryptMessage()
        {
            // Arrange
            var basicNotification = new BasicNotification();
            var encryptionDecorator = new EncryptionDecorator(basicNotification);

            // Act
            var output = CaptureConsoleOutput(() => encryptionDecorator.Send("Secret"));

            // Assert
            Assert.Contains("[Encrypted]", output);
            Assert.Contains("Secret", output);
        }

        [Fact]
        public void PrioritizationDecorator_Send_ShouldPrioritizeMessage()
        {
            // Arrange
            var basicNotification = new BasicNotification();
            var prioritizationDecorator = new PrioritizationDecorator(basicNotification);

            // Act
            var output = CaptureConsoleOutput(() => prioritizationDecorator.Send("Urgent"));

            // Assert
            Assert.Contains("[Priority]", output);
            Assert.Contains("Urgent", output);
        }

        [Fact]
        public void ChainedDecorators_ShouldApplyAllDecorations()
        {
            // Arrange
            var basicNotification = new BasicNotification();
            var encrypted = new EncryptionDecorator(basicNotification);
            var prioritized = new PrioritizationDecorator(encrypted);
            var logged = new LoggingDecorator(prioritized);

            // Act
            var output = CaptureConsoleOutput(() => logged.Send("Important"));

            // Assert
            Assert.Contains("Logging notification", output);
            Assert.Contains("[Priority]", output);
            Assert.Contains("[Encrypted]", output);
            Assert.Contains("Important", output);
        }

        [Fact]
        public void EncryptionThenPrioritization_ShouldApplyInOrder()
        {
            // Arrange - Prioritization wraps Encryption, so Priority is applied first, then Encryption
            var basicNotification = new BasicNotification();
            var encrypted = new EncryptionDecorator(basicNotification);
            var prioritized = new PrioritizationDecorator(encrypted);

            // Act
            var output = CaptureConsoleOutput(() => prioritized.Send("Data"));

            // Assert - Priority applied first transforms to [Priority]Data, then Encryption transforms to [Encrypted][Priority]Data
            Assert.Contains("[Encrypted][Priority]Data", output);
        }

        [Fact]
        public void PrioritizationThenEncryption_ShouldApplyInOrder()
        {
            // Arrange - Encryption wraps Prioritization, so Encryption is applied first, then Priority
            var basicNotification = new BasicNotification();
            var prioritized = new PrioritizationDecorator(basicNotification);
            var encrypted = new EncryptionDecorator(prioritized);

            // Act
            var output = CaptureConsoleOutput(() => encrypted.Send("Data"));

            // Assert - Encryption applied first transforms to [Encrypted]Data, then Priority transforms to [Priority][Encrypted]Data
            Assert.Contains("[Priority][Encrypted]Data", output);
        }

        [Fact]
        public void MultipleLoggingDecorators_ShouldLogMultipleTimes()
        {
            // Arrange
            var basicNotification = new BasicNotification();
            var logging1 = new LoggingDecorator(basicNotification);
            var logging2 = new LoggingDecorator(logging1);

            // Act
            var output = CaptureConsoleOutput(() => logging2.Send("Message"));

            // Assert
            var loggingCount = output.Split("Logging notification").Length - 1;
            Assert.Equal(2, loggingCount);
        }

        [Fact]
        public void Decorator_InheritsFromNotification()
        {
            // Arrange
            var basicNotification = new BasicNotification();
            var decorator = new LoggingDecorator(basicNotification);

            // Assert
            Assert.IsAssignableFrom<Notification>(decorator);
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
