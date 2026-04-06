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
            var fileSystem = new FileSystemReceiver();
            var command = new CreateFileCommand(fileSystem, "test.txt");
            var output = CaptureConsoleOutput(() => command.Execute());

            // Assert
            Assert.Contains("Creating file: test.txt", output);
        }

        [Fact]
        public void CreateFileCommand_Undo_ShouldDeleteFile()
        {
            // Arrange
            var fileSystem = new FileSystemReceiver();
            var command = new CreateFileCommand(fileSystem, "test.txt");

            // Act
            var output = CaptureConsoleOutput(() => command.Undo());

            // Assert
            Assert.Contains("Deleting file: test.txt", output);
        }

        [Fact]
        public void WriteFileCommand_Execute_ShouldWriteToFile()
        {
            // Arrange
            var fileSystem = new FileSystemReceiver();
            var command = new WriteFileCommand(fileSystem, "test.txt", "Hello World");

            // Act
            var output = CaptureConsoleOutput(() => command.Execute());

            // Assert
            Assert.Contains("Writing to file: test.txt", output);
            Assert.Contains("Content: Hello World", output);
        }

        [Fact]
        public void DeleteFileCommand_Execute_ShouldDeleteFile()
        {
            // Arrange
            var fileSystem = new FileSystemReceiver();
            var command = new DeleteFileCommand(fileSystem, "test.txt");

            // Act
            var output = CaptureConsoleOutput(() => command.Execute());

            // Assert
            Assert.Contains("Deleting file: test.txt", output);
        }

        [Fact]
        public void FileInvoker_Execute_ShouldInvokeCommand()
        {
            // Arrange
            var fileSystem = new FileSystemReceiver();
            var command = new CreateFileCommand(fileSystem, "invoker_test.txt");
            var invoker = new FileInvoker(command);

            // Act
            var output = CaptureConsoleOutput(() => invoker.Execute());

            // Assert
            Assert.Contains("Creating file: invoker_test.txt", output);
        }

        [Fact]
        public void FileInvoker_Undo_ShouldUndoCommand()
        {
            // Arrange
            var fileSystem = new FileSystemReceiver();
            var command = new CreateFileCommand(fileSystem, "invoker_test.txt");
            var invoker = new FileInvoker(command);

            // Act
            var output = CaptureConsoleOutput(() => invoker.Undo());

            // Assert
            Assert.Contains("Deleting file: invoker_test.txt", output);
        }

        [Fact]
        public void FileInvoker_Constructor_ShouldThrowArgumentNullException_WhenCommandIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FileInvoker(null!));
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
