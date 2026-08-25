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
            var output = new StringWriter();
            var notification = new BasicNotification { Output = output };

            // Act
            notification.Send("Hello World");

            // Assert
            Assert.Contains("Hello World", output.ToString());
            Assert.Contains("Sending notification", output.ToString());
        }

        [Fact]
        public void LoggingDecorator_Send_ShouldLogAndSendMessage()
        {
            // Arrange
            var output = new StringWriter();
            var basicNotification = new BasicNotification { Output = output };
            var loggingDecorator = new LoggingDecorator(basicNotification) { Output = output };

            // Act
            loggingDecorator.Send("Test Message");

            // Assert
            Assert.Contains("Logging notification", output.ToString());
            Assert.Contains("Sending notification", output.ToString());
            Assert.Contains("Test Message", output.ToString());
        }

        [Fact]
        public void EncryptionDecorator_Send_ShouldEncryptMessage()
        {
            // Arrange
            var output = new StringWriter();
            var basicNotification = new BasicNotification { Output = output };
            var encryptionDecorator = new EncryptionDecorator(basicNotification) { Output = output };

            // Act
            encryptionDecorator.Send("Secret");

            // Assert
            Assert.Contains("[Encrypted]", output.ToString());
            Assert.Contains("Secret", output.ToString());
        }

        [Fact]
        public void PrioritizationDecorator_Send_ShouldPrioritizeMessage()
        {
            // Arrange
            var output = new StringWriter();
            var basicNotification = new BasicNotification { Output = output };
            var prioritizationDecorator = new PrioritizationDecorator(basicNotification) { Output = output };

            // Act
            prioritizationDecorator.Send("Urgent");

            // Assert
            Assert.Contains("[Priority]", output.ToString());
            Assert.Contains("Urgent", output.ToString());
        }

        [Fact]
        public void ChainedDecorators_ShouldApplyAllDecorations()
        {
            // Arrange
            var output = new StringWriter();
            var basicNotification = new BasicNotification { Output = output };
            var encrypted = new EncryptionDecorator(basicNotification) { Output = output };
            var prioritized = new PrioritizationDecorator(encrypted) { Output = output };
            var logged = new LoggingDecorator(prioritized) { Output = output };

            // Act
            logged.Send("Important");

            // Assert
            Assert.Contains("Logging notification", output.ToString());
            Assert.Contains("[Priority]", output.ToString());
            Assert.Contains("[Encrypted]", output.ToString());
            Assert.Contains("Important", output.ToString());
        }

        [Fact]
        public void EncryptionThenPrioritization_ShouldApplyInOrder()
        {
            var output = new StringWriter();
            // Arrange - Prioritization wraps Encryption, so Priority is applied first, then Encryption
            var basicNotification = new BasicNotification { Output = output };
            var encrypted = new EncryptionDecorator(basicNotification) { Output = output };
            var prioritized = new PrioritizationDecorator(encrypted) { Output = output };

            // Act
            prioritized.Send("Data");

            // Assert - Priority applied first transforms to [Priority]Data, then Encryption transforms to [Encrypted][Priority]Data
            Assert.Contains("[Encrypted][Priority]Data", output.ToString());
        }

        [Fact]
        public void PrioritizationThenEncryption_ShouldApplyInOrder()
        {
            var output = new StringWriter();
            // Arrange - Encryption wraps Prioritization, so Encryption is applied first, then Priority
            var basicNotification = new BasicNotification { Output = output };
            var prioritized = new PrioritizationDecorator(basicNotification) { Output = output };
            var encrypted = new EncryptionDecorator(prioritized) { Output = output };

            // Act
            encrypted.Send("Data");

            // Assert - Encryption applied first transforms to [Encrypted]Data, then Priority transforms to [Priority][Encrypted]Data
            Assert.Contains("[Priority][Encrypted]Data", output.ToString());
        }

        [Fact]
        public void MultipleLoggingDecorators_ShouldLogMultipleTimes()
        {
            // Arrange
            var output = new StringWriter();
            var basicNotification = new BasicNotification { Output = output };
            var logging1 = new LoggingDecorator(basicNotification) { Output = output };
            var logging2 = new LoggingDecorator(logging1) { Output = output };

            // Act
            logging2.Send("Message");

            // Assert
            var loggingCount = output.ToString().Split("Logging notification").Length - 1;
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

    }
}
