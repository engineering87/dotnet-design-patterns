// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Structural.Facade;

namespace DotnetDesignPatterns.Tests.Structural.Facade
{
    public class FacadeTests
    {
        [Fact]
        public void FileReader_ReadFile_ShouldReturnContent()
        {
            // Arrange
            var reader = new FileReader();

            // Act
            var content = reader.ReadFile("test.txt");

            // Assert
            Assert.NotNull(content);
            Assert.Equal("File content", content);
        }

        [Fact]
        public void FileReader_ReadFile_ShouldOutputReadingMessage()
        {
            // Arrange
            var reader = new FileReader();

            // Act
            var output = CaptureConsoleOutput(() => reader.ReadFile("document.pdf"));

            // Assert
            Assert.Contains("Reading file from", output);
            Assert.Contains("document.pdf", output);
        }

        [Fact]
        public void FileWriter_WriteFile_ShouldOutputWritingMessage()
        {
            // Arrange
            var writer = new FileWriter();

            // Act
            var output = CaptureConsoleOutput(() => writer.WriteFile("output.txt", "content"));

            // Assert
            Assert.Contains("Writing to file at", output);
            Assert.Contains("output.txt", output);
        }

        [Fact]
        public void FileValidator_Validate_ShouldReturnTrue()
        {
            // Arrange
            var validator = new FileValidator();

            // Act
            var isValid = validator.Validate("test.txt");

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void FileValidator_Validate_ShouldOutputValidationMessage()
        {
            // Arrange
            var validator = new FileValidator();

            // Act
            var output = CaptureConsoleOutput(() => validator.Validate("config.xml"));

            // Assert
            Assert.Contains("Validating file at", output);
            Assert.Contains("config.xml", output);
        }

        [Fact]
        public void FileManagerFacade_ProcessFile_ShouldCoordinateSubsystems()
        {
            // Arrange
            var facade = new FileManagerFacade();

            // Act
            var output = CaptureConsoleOutput(() => facade.ProcessFile("input.txt", "new content"));

            // Assert
            Assert.Contains("Validating", output);
            Assert.Contains("Reading", output);
            Assert.Contains("Writing", output);
            Assert.Contains("processed successfully", output);
        }

        [Fact]
        public void FileManagerFacade_ProcessFile_ShouldValidateFirst()
        {
            // Arrange
            var facade = new FileManagerFacade();

            // Act
            var output = CaptureConsoleOutput(() => facade.ProcessFile("test.txt", "content"));

            // Assert
            var validateIndex = output.IndexOf("Validating");
            var readIndex = output.IndexOf("Reading");
            var writeIndex = output.IndexOf("Writing");

            Assert.True(validateIndex < readIndex, "Validation should happen before reading");
            Assert.True(readIndex < writeIndex, "Reading should happen before writing");
        }

        [Fact]
        public void FileManagerFacade_SimplifiesComplexOperations()
        {
            // Arrange
            var facade = new FileManagerFacade();

            // Act & Assert - Single method call handles multiple subsystem operations
            var exception = Record.Exception(() => facade.ProcessFile("doc.txt", "updated"));
            Assert.Null(exception);
        }

        [Fact]
        public void FileManagerFacade_OutputsCurrentContent()
        {
            // Arrange
            var facade = new FileManagerFacade();

            // Act
            var output = CaptureConsoleOutput(() => facade.ProcessFile("test.txt", "new"));

            // Assert
            Assert.Contains("Current content", output);
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
