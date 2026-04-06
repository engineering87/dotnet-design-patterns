// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.Interpreter;
using File = DotnetDesignPatterns.Behavioral.Interpreter.File;

namespace DotnetDesignPatterns.Tests.Behavioral.Interpreter
{
    public class InterpreterTests
    {
        [Fact]
        public void FilenameFilter_Interpret_MatchingFilename_ShouldReturnTrue()
        {
            // Arrange
            var filter = new FilenameFilter("document");
            var file = new File("document", "pdf");

            // Act
            var result = filter.Interpret(file);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void FilenameFilter_Interpret_NonMatchingFilename_ShouldReturnFalse()
        {
            // Arrange
            var filter = new FilenameFilter("report");
            var file = new File("document", "pdf");

            // Act
            var result = filter.Interpret(file);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void FilenameFilter_Interpret_PartialMatch_ShouldReturnTrue()
        {
            // Arrange
            var filter = new FilenameFilter("doc");
            var file = new File("document", "pdf");

            // Act
            var result = filter.Interpret(file);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void FilenameFilter_Interpret_CaseInsensitive_ShouldReturnTrue()
        {
            // Arrange
            var filter = new FilenameFilter("DOCUMENT");
            var file = new File("document", "pdf");

            // Act
            var result = filter.Interpret(file);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ExtensionFilter_Interpret_MatchingExtension_ShouldReturnTrue()
        {
            // Arrange
            var filter = new ExtensionFilter("pdf");
            var file = new File("document", "pdf");

            // Act
            var result = filter.Interpret(file);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ExtensionFilter_Interpret_NonMatchingExtension_ShouldReturnFalse()
        {
            // Arrange
            var filter = new ExtensionFilter("txt");
            var file = new File("document", "pdf");

            // Act
            var result = filter.Interpret(file);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ExtensionFilter_Interpret_CaseInsensitive_ShouldReturnTrue()
        {
            // Arrange
            var filter = new ExtensionFilter("PDF");
            var file = new File("document", "pdf");

            // Act
            var result = filter.Interpret(file);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void File_Properties_ShouldReturnCorrectValues()
        {
            // Arrange & Act
            var file = new File("report", "xlsx");

            // Assert
            Assert.Equal("report", file.Name);
            Assert.Equal("xlsx", file.Extension);
        }

        [Fact]
        public void CombinedFilters_FilenameAndExtension_ShouldWorkTogether()
        {
            // Arrange
            var filenameFilter = new FilenameFilter("document");
            var extensionFilter = new ExtensionFilter("pdf");
            var file1 = new File("document", "pdf");
            var file2 = new File("document", "txt");
            var file3 = new File("report", "pdf");

            // Act & Assert
            Assert.True(filenameFilter.Interpret(file1) && extensionFilter.Interpret(file1));
            Assert.True(filenameFilter.Interpret(file2) && !extensionFilter.Interpret(file2));
            Assert.True(!filenameFilter.Interpret(file3) && extensionFilter.Interpret(file3));
        }
    }
}
