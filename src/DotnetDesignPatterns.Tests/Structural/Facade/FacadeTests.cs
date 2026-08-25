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
            var output = new StringWriter();
            var reader = new FileReader { Output = output };

            // Act
            reader.ReadFile("document.pdf");

            // Assert
            Assert.Contains("Reading file from", output.ToString());
            Assert.Contains("document.pdf", output.ToString());
        }

        [Fact]
        public void FileWriter_WriteFile_ShouldOutputWritingMessage()
        {
            // Arrange
            var output = new StringWriter();
            var writer = new FileWriter { Output = output };

            // Act
            writer.WriteFile("output.txt", "content");

            // Assert
            Assert.Contains("Writing to file at", output.ToString());
            Assert.Contains("output.txt", output.ToString());
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
            var output = new StringWriter();
            var validator = new FileValidator { Output = output };

            // Act
            validator.Validate("config.xml");

            // Assert
            Assert.Contains("Validating file at", output.ToString());
            Assert.Contains("config.xml", output.ToString());
        }

        [Fact]
        public void FileManagerFacade_ProcessFile_ShouldCoordinateSubsystems()
        {
            // Arrange
            var output = new StringWriter();
            var facade = new FileManagerFacade { Output = output };

            // Act
            facade.ProcessFile("input.txt", "new content");

            // Assert
            Assert.Contains("Validating", output.ToString());
            Assert.Contains("Reading", output.ToString());
            Assert.Contains("Writing", output.ToString());
            Assert.Contains("processed successfully", output.ToString());
        }

        [Fact]
        public void FileManagerFacade_ProcessFile_ShouldValidateFirst()
        {
            // Arrange
            var output = new StringWriter();
            var facade = new FileManagerFacade { Output = output };

            // Act
            facade.ProcessFile("test.txt", "content");

            // Assert
            var text = output.ToString();
            var validateIndex = text.IndexOf("Validating", StringComparison.Ordinal);
            var readIndex = text.IndexOf("Reading", StringComparison.Ordinal);
            var writeIndex = text.IndexOf("Writing", StringComparison.Ordinal);

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
            var output = new StringWriter();
            var facade = new FileManagerFacade { Output = output };

            // Act
            facade.ProcessFile("test.txt", "new");

            // Assert
            Assert.Contains("Current content", output.ToString());
        }

    }
}
