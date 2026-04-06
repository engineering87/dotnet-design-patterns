// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.State;

namespace DotnetDesignPatterns.Tests.Behavioral.State
{
    public class StateTests
    {
        [Fact]
        public void FileContext_InitialState_ShouldBeCreatedState()
        {
            // Arrange & Act
            var context = new FileContext();

            // Assert
            Assert.IsType<CreatedState>(context.State);
        }

        [Fact]
        public void FileContext_Open_FromCreatedState_ShouldTransitionToOpenedState()
        {
            // Arrange
            var context = new FileContext();

            // Act
            context.Open();

            // Assert
            Assert.IsType<OpenedState>(context.State);
        }

        [Fact]
        public void FileContext_Close_FromOpenedState_ShouldTransitionToClosedState()
        {
            // Arrange
            var context = new FileContext();
            context.Open();

            // Act
            context.Close();

            // Assert
            Assert.IsType<ClosedState>(context.State);
        }

        [Fact]
        public void FileContext_Open_FromClosedState_ShouldTransitionToOpenedState()
        {
            // Arrange
            var context = new FileContext();
            context.Open();
            context.Close();

            // Act
            context.Open();

            // Assert
            Assert.IsType<OpenedState>(context.State);
        }

        [Fact]
        public void FileContext_Edit_FromOpenedState_ShouldNotChangeState()
        {
            // Arrange
            var context = new FileContext();
            context.Open();

            // Act
            var output = CaptureConsoleOutput(() => context.Edit());

            // Assert
            Assert.IsType<OpenedState>(context.State);
            Assert.Contains("File is being edited", output);
        }

        [Fact]
        public void FileContext_Edit_FromClosedState_ShouldNotAllowEdit()
        {
            // Arrange
            var context = new FileContext();
            context.Open();
            context.Close();

            // Act
            var output = CaptureConsoleOutput(() => context.Edit());

            // Assert
            Assert.Contains("Cannot edit the file. It is closed", output);
        }

        [Fact]
        public void FileContext_Edit_FromCreatedState_ShouldNotAllowEdit()
        {
            // Arrange
            var context = new FileContext();

            // Act
            var output = CaptureConsoleOutput(() => context.Edit());

            // Assert
            Assert.Contains("Cannot edit the file. It is not opened", output);
        }

        [Fact]
        public void FileContext_Open_WhenAlreadyOpened_ShouldIndicateAlreadyOpen()
        {
            // Arrange
            var context = new FileContext();
            context.Open();

            // Act
            var output = CaptureConsoleOutput(() => context.Open());

            // Assert
            Assert.Contains("File is already opened", output);
        }

        [Fact]
        public void FileContext_Close_WhenAlreadyClosed_ShouldIndicateAlreadyClosed()
        {
            // Arrange
            var context = new FileContext();
            context.Open();
            context.Close();

            // Act
            var output = CaptureConsoleOutput(() => context.Close());

            // Assert
            Assert.Contains("File is already closed", output);
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
