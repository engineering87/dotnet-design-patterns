// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.Mediator;

namespace DotnetDesignPatterns.Tests.Behavioral.Mediator
{
    public class MediatorTests
    {
        private static (FileExplorer Explorer, FileOperationHandler Handler, Logger Logger) CreateSystem()
        {
            var explorer = new FileExplorer();
            var handler = new FileOperationHandler();
            var logger = new Logger();

            // The constructor of the mediator is what wires the colleagues together.
            _ = new FileManager(explorer, handler, logger);

            return (explorer, handler, logger);
        }

        [Fact]
        public void SelectFile_ShouldSetCurrentFile()
        {
            // Arrange
            var (explorer, _, _) = CreateSystem();

            // Act
            explorer.SelectFile("report.txt");

            // Assert
            Assert.Equal("report.txt", explorer.CurrentFile);
        }

        [Fact]
        public void SelectFile_WithEmptyName_ShouldThrowArgumentException()
        {
            // Arrange
            var (explorer, _, _) = CreateSystem();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => explorer.SelectFile("   "));
        }

        [Fact]
        public void CreateFile_ShouldReachTheHandlerAndTheLogger()
        {
            // Arrange
            var (explorer, handler, logger) = CreateSystem();
            explorer.SelectFile("report.txt");

            // Act
            explorer.CreateFile();

            // Assert
            Assert.Equal("Creating file: report.txt", string.Join(" | ", handler.Operations));
            Assert.Equal("File created: report.txt", string.Join(" | ", logger.Entries));
        }

        [Fact]
        public void OpenFile_ShouldReachTheHandlerAndTheLogger()
        {
            // Arrange
            var (explorer, handler, logger) = CreateSystem();
            explorer.SelectFile("report.txt");

            // Act
            explorer.OpenFile();

            // Assert
            Assert.Equal("Opening file: report.txt", string.Join(" | ", handler.Operations));
            Assert.Equal("File opened: report.txt", string.Join(" | ", logger.Entries));
        }

        [Fact]
        public void DeleteFile_ShouldReachTheHandlerAndTheLogger()
        {
            // Arrange
            var (explorer, handler, logger) = CreateSystem();
            explorer.SelectFile("report.txt");

            // Act
            explorer.DeleteFile();

            // Assert
            Assert.Equal("Deleting file: report.txt", string.Join(" | ", handler.Operations));
            Assert.Equal("File deleted: report.txt", string.Join(" | ", logger.Entries));
        }

        [Fact]
        public void Operations_ShouldBeRecordedInOrder()
        {
            // Arrange
            var (explorer, handler, logger) = CreateSystem();

            // Act
            explorer.SelectFile("first.txt");
            explorer.CreateFile();
            explorer.OpenFile();
            explorer.SelectFile("second.txt");
            explorer.DeleteFile();

            // Assert
            Assert.Equal(
                "Creating file: first.txt | Opening file: first.txt | Deleting file: second.txt",
                string.Join(" | ", handler.Operations));

            Assert.Equal(
                "File created: first.txt | File opened: first.txt | File deleted: second.txt",
                string.Join(" | ", logger.Entries));
        }

        [Fact]
        public void Colleague_WithoutSelectedFile_ShouldDoNothing()
        {
            // Arrange
            var (explorer, handler, logger) = CreateSystem();

            // Act
            explorer.CreateFile();
            explorer.OpenFile();
            explorer.DeleteFile();

            // Assert
            Assert.Empty(handler.Operations);
            Assert.Empty(logger.Entries);
        }

        [Fact]
        public void Colleague_WithoutMediator_ShouldDoNothing()
        {
            // Arrange
            var explorer = new FileExplorer();
            explorer.SelectFile("orphan.txt");

            // Act
            var exception = Record.Exception(() => explorer.CreateFile());

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void FileManager_ShouldAttachItselfToEveryColleague()
        {
            // Arrange
            var handler = new FileOperationHandler();
            var logger = new Logger();

            // Act
            _ = new FileManager(new FileExplorer(), handler, logger);

            // Assert
            Assert.True(handler.IsAttached);
            Assert.True(logger.IsAttached);
        }

        [Fact]
        public void Colleague_ShouldNotBeAttachedBeforeAMediatorExists()
        {
            // Assert
            Assert.False(new FileOperationHandler().IsAttached);
            Assert.False(new Logger().IsAttached);
        }

        [Fact]
        public void SetMediator_WithNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var explorer = new FileExplorer();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => explorer.SetMediator(null!));
        }

        [Fact]
        public void FileManager_WithNullColleague_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new FileManager(null!, new FileOperationHandler(), new Logger()));
            Assert.Throws<ArgumentNullException>(
                () => new FileManager(new FileExplorer(), null!, new Logger()));
            Assert.Throws<ArgumentNullException>(
                () => new FileManager(new FileExplorer(), new FileOperationHandler(), null!));
        }

        [Fact]
        public void Notify_WithUnknownEventCode_ShouldNotLogAnything()
        {
            // Arrange
            var explorer = new FileExplorer();
            var logger = new Logger();
            var mediator = new FileManager(explorer, new FileOperationHandler(), logger);
            explorer.SelectFile("report.txt");

            // Act
            mediator.Notify(explorer, "SomethingElse");

            // Assert
            Assert.Empty(logger.Entries);
        }

        [Fact]
        public void Notify_WithUnknownSender_ShouldNotLogAnything()
        {
            // Arrange
            var logger = new Logger();
            var mediator = new FileManager(new FileExplorer(), new FileOperationHandler(), logger);

            // Act
            mediator.Notify(new object(), FileEvents.FileCreated);

            // Assert
            Assert.Empty(logger.Entries);
        }
    }
}
