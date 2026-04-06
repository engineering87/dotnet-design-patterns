// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.Observer;

namespace DotnetDesignPatterns.Tests.Behavioral.Observer
{
    public class ObserverTests
    {
        [Fact]
        public void FileWatcher_RegisterObserver_ShouldAddObserver()
        {
            // Arrange
            using var fileWatcher = new FileWatcher();
            var observer = new ConsoleLogger();

            // Act
            var exception = Record.Exception(() => fileWatcher.RegisterObserver(observer));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void FileWatcher_RegisterObserver_ShouldThrowArgumentNullException_WhenObserverIsNull()
        {
            // Arrange
            using var fileWatcher = new FileWatcher();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => fileWatcher.RegisterObserver(null!));
        }

        [Fact]
        public void FileWatcher_UnregisterObserver_ShouldThrowArgumentNullException_WhenObserverIsNull()
        {
            // Arrange
            using var fileWatcher = new FileWatcher();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => fileWatcher.UnregisterObserver(null!));
        }

        [Fact]
        public void FileWatcher_NotifyObservers_ShouldNotifyAllRegisteredObservers()
        {
            // Arrange
            using var fileWatcher = new FileWatcher();
            var observer1 = new TestObserver();
            var observer2 = new TestObserver();
            fileWatcher.RegisterObserver(observer1);
            fileWatcher.RegisterObserver(observer2);

            // Act
            fileWatcher.NotifyObservers("test.txt", "created");

            // Assert
            Assert.True(observer1.WasNotified);
            Assert.True(observer2.WasNotified);
            Assert.Equal("test.txt", observer1.LastFileName);
            Assert.Equal("created", observer1.LastChangeType);
        }

        [Fact]
        public void FileWatcher_UnregisterObserver_ShouldRemoveObserver()
        {
            // Arrange
            using var fileWatcher = new FileWatcher();
            var observer = new TestObserver();
            fileWatcher.RegisterObserver(observer);

            // Act
            fileWatcher.UnregisterObserver(observer);
            fileWatcher.NotifyObservers("test.txt", "deleted");

            // Assert
            Assert.False(observer.WasNotified);
        }

        [Fact]
        public void FileWatcher_StartWatching_ShouldThrowArgumentException_WhenPathIsNullOrEmpty()
        {
            // Arrange
            using var fileWatcher = new FileWatcher();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => fileWatcher.StartWatching(null!));
            Assert.Throws<ArgumentException>(() => fileWatcher.StartWatching(""));
            Assert.Throws<ArgumentException>(() => fileWatcher.StartWatching("   "));
        }

        [Fact]
        public void FileWatcher_Dispose_ShouldNotThrowException()
        {
            // Arrange
            var fileWatcher = new FileWatcher();

            // Act & Assert
            var exception = Record.Exception(() => fileWatcher.Dispose());
            Assert.Null(exception);
        }

        [Fact]
        public void FileWatcher_Dispose_CalledMultipleTimes_ShouldNotThrowException()
        {
            // Arrange
            var fileWatcher = new FileWatcher();

            // Act & Assert
            var exception = Record.Exception(() =>
            {
                fileWatcher.Dispose();
                fileWatcher.Dispose();
            });
            Assert.Null(exception);
        }

        [Fact]
        public void ConsoleLogger_Update_ShouldLogMessage()
        {
            // Arrange
            var logger = new ConsoleLogger();

            // Act
            var output = CaptureConsoleOutput(() => logger.Update("test.txt", "modified"));

            // Assert
            Assert.Contains("test.txt", output);
            Assert.Contains("modified", output);
        }

        [Fact]
        public void EmailNotifier_Update_ShouldSendNotification()
        {
            // Arrange
            var notifier = new EmailNotifier();

            // Act
            var output = CaptureConsoleOutput(() => notifier.Update("document.pdf", "created"));

            // Assert
            Assert.Contains("document.pdf", output);
            Assert.Contains("created", output);
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

        private class TestObserver : IFileObserver
        {
            public bool WasNotified { get; private set; }
            public string? LastFileName { get; private set; }
            public string? LastChangeType { get; private set; }

            public void Update(string fileName, string changeType)
            {
                WasNotified = true;
                LastFileName = fileName;
                LastChangeType = changeType;
            }
        }
    }
}
