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
            var output = new StringWriter();
            var context = new FileContext { Output = output };

            // Assert
            Assert.IsType<CreatedState>(context.State);
        }

        [Fact]
        public void FileContext_Open_FromCreatedState_ShouldTransitionToOpenedState()
        {
            // Arrange
            var output = new StringWriter();
            var context = new FileContext { Output = output };

            // Act
            context.Open();

            // Assert
            Assert.IsType<OpenedState>(context.State);
        }

        [Fact]
        public void FileContext_Close_FromOpenedState_ShouldTransitionToClosedState()
        {
            // Arrange
            var output = new StringWriter();
            var context = new FileContext { Output = output };
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
            var output = new StringWriter();
            var context = new FileContext { Output = output };
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
            var output = new StringWriter();
            var context = new FileContext { Output = output };
            context.Open();

            // Act
            context.Edit();

            // Assert
            Assert.IsType<OpenedState>(context.State);
            Assert.Contains("File is being edited", output.ToString());
        }

        [Fact]
        public void FileContext_Edit_FromClosedState_ShouldNotAllowEdit()
        {
            // Arrange
            var output = new StringWriter();
            var context = new FileContext { Output = output };
            context.Open();
            context.Close();

            // Act
            context.Edit();

            // Assert
            Assert.Contains("Cannot edit the file. It is closed", output.ToString());
        }

        [Fact]
        public void FileContext_Edit_FromCreatedState_ShouldNotAllowEdit()
        {
            // Arrange
            var output = new StringWriter();
            var context = new FileContext { Output = output };

            // Act
            context.Edit();

            // Assert
            Assert.Contains("Cannot edit the file. It is not opened", output.ToString());
        }

        [Fact]
        public void FileContext_Open_WhenAlreadyOpened_ShouldIndicateAlreadyOpen()
        {
            // Arrange
            var output = new StringWriter();
            var context = new FileContext { Output = output };
            context.Open();

            // Act
            context.Open();

            // Assert
            Assert.Contains("File is already opened", output.ToString());
        }

        [Fact]
        public void FileContext_Close_WhenAlreadyClosed_ShouldIndicateAlreadyClosed()
        {
            // Arrange
            var output = new StringWriter();
            var context = new FileContext { Output = output };
            context.Open();
            context.Close();

            // Act
            context.Close();

            // Assert
            Assert.Contains("File is already closed", output.ToString());
        }

    }
}
