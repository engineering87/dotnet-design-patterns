// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.Command;

namespace DotnetDesignPatterns.Tests.Behavioral.Command
{
    public class CommandTests
    {
        [Fact]
        public void CreateFileCommand_Execute_ShouldCreateFile()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new FileSystemReceiver { Output = output };
            var command = new CreateFileCommand(fileSystem, "test.txt");
            command.Execute();

            // Assert
            Assert.Contains("Creating file: test.txt", output.ToString());
        }

        [Fact]
        public void CreateFileCommand_Undo_ShouldDeleteFile()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new FileSystemReceiver { Output = output };
            var command = new CreateFileCommand(fileSystem, "test.txt");

            // Act
            command.Undo();

            // Assert
            Assert.Contains("Deleting file: test.txt", output.ToString());
        }

        [Fact]
        public void WriteFileCommand_Execute_ShouldWriteToFile()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new FileSystemReceiver { Output = output };
            var command = new WriteFileCommand(fileSystem, "test.txt", "Hello World") { Output = output };

            // Act
            command.Execute();

            // Assert
            Assert.Contains("Writing to file: test.txt", output.ToString());
            Assert.Contains("Content: Hello World", output.ToString());
        }

        [Fact]
        public void DeleteFileCommand_Execute_ShouldDeleteFile()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new FileSystemReceiver { Output = output };
            var command = new DeleteFileCommand(fileSystem, "test.txt") { Output = output };

            // Act
            command.Execute();

            // Assert
            Assert.Contains("Deleting file: test.txt", output.ToString());
        }

        [Fact]
        public void FileInvoker_Execute_ShouldInvokeCommand()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new FileSystemReceiver { Output = output };
            var command = new CreateFileCommand(fileSystem, "invoker_test.txt");
            var invoker = new FileInvoker();

            // Act
            invoker.Execute(command);

            // Assert
            Assert.Contains("Creating file: invoker_test.txt", output.ToString());
        }

        [Fact]
        public void FileInvoker_Execute_ShouldRecordTheCommandInTheHistory()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new FileSystemReceiver { Output = output };
            var command = new CreateFileCommand(fileSystem, "invoker_test.txt");
            var invoker = new FileInvoker();

            // Act
            invoker.Execute(command);

            // Assert
            Assert.Single(invoker.History);
            Assert.Same(command, invoker.History[0]);
        }

        [Fact]
        public void FileInvoker_Undo_ShouldUndoTheMostRecentCommand()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new FileSystemReceiver { Output = output };
            var invoker = new FileInvoker();
            invoker.Execute(new CreateFileCommand(fileSystem, "first.txt"));
            invoker.Execute(new CreateFileCommand(fileSystem, "second.txt"));

            // Act
            invoker.Undo();

            // Assert
            Assert.Contains("Deleting file: second.txt", output.ToString());
            Assert.Single(invoker.History);
        }

        [Fact]
        public void FileInvoker_Undo_WithEmptyHistory_ShouldReportNothingToUndo()
        {
            // Arrange
            var invoker = new FileInvoker();

            // Act
            var undone = invoker.Undo();

            // Assert
            Assert.False(undone);
        }

        [Fact]
        public void FileInvoker_UndoAll_ShouldEmptyTheHistory()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new FileSystemReceiver { Output = output };
            var invoker = new FileInvoker();
            invoker.Execute(new CreateFileCommand(fileSystem, "a.txt"));
            invoker.Execute(new WriteFileCommand(fileSystem, "a.txt", "content") { Output = output });

            // Act
            invoker.UndoAll();

            // Assert
            Assert.Empty(invoker.History);
        }

        [Fact]
        public void FileInvoker_Execute_ShouldThrowArgumentNullException_WhenCommandIsNull()
        {
            // Arrange
            var invoker = new FileInvoker();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => invoker.Execute(null!));
        }

    }
}
