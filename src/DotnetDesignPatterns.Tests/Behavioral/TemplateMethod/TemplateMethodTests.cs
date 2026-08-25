// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.TemplateMethod;

namespace DotnetDesignPatterns.Tests.Behavioral.TemplateMethod
{
    public class TemplateMethodTests
    {
        [Fact]
        public void ProcessFile_ShouldRunTheStepsInTheOrderDefinedByTheTemplate()
        {
            // Arrange
            var processor = new RecordingFileProcessor();

            // Act
            processor.ProcessFile("test.txt");

            // Assert
            Assert.Equal("OpenFile > ReadFileContent > ProcessContent > CloseFile",
                string.Join(" > ", processor.CallOrder));
        }

        [Fact]
        public void ProcessFile_ShouldPassTheContentReadToTheProcessingStep()
        {
            // Arrange
            var processor = new RecordingFileProcessor { Content = "content to be processed" };

            // Act
            processor.ProcessFile("test.txt");

            // Assert
            Assert.Equal("content to be processed", processor.ReceivedContent);
        }

        [Fact]
        public void OpenFile_AndCloseFile_ShouldHaveAUsableDefaultImplementation()
        {
            // Arrange
            var output = new StringWriter();
            var processor = new DefaultStepsFileProcessor { Output = output };

            // Act
            processor.ProcessFile("test.txt");

            // Assert
            Assert.Contains("Opening file: test.txt", output.ToString());
            Assert.Contains("Closing file.", output.ToString());
        }

        [Fact]
        public void TextFileProcessor_ShouldReadAndUppercaseTheFileContent()
        {
            // Arrange
            var output = new StringWriter();
            var path = CreateTemporaryFile("hello template method");
            var processor = new TextFileProcessor { Output = output };

            try
            {
                // Act
                processor.ProcessFile(path);

                // Assert
                Assert.Contains("Reading text file content", output.ToString());
                Assert.Contains("HELLO TEMPLATE METHOD", output.ToString());
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void TextFileProcessor_ShouldReleaseTheFileHandleWhenDone()
        {
            // Arrange
            var output = new StringWriter();
            var path = CreateTemporaryFile("content");
            var processor = new TextFileProcessor { Output = output };

            try
            {
                // Act
                processor.ProcessFile(path);

                // Assert: the file can be deleted only if the reader was disposed
                var exception = Record.Exception(() => File.Delete(path));
                Assert.Null(exception);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        [Fact]
        public void CsvFileProcessor_ShouldProcessEveryNonEmptyLine()
        {
            // Arrange
            var output = new StringWriter();
            var path = CreateTemporaryFile("name,size\nreport.txt,120\n\nnotes.txt,64");
            var processor = new CsvFileProcessor { Output = output };

            try
            {
                // Act
                processor.ProcessFile(path);

                // Assert
                Assert.Contains("Reading CSV file content", output.ToString());
                Assert.Contains("name | size", output.ToString());
                Assert.Contains("report.txt | 120", output.ToString());
                Assert.Contains("notes.txt | 64", output.ToString());
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void CsvFileProcessor_WithEmptyFile_ShouldProcessNothing()
        {
            // Arrange
            var output = new StringWriter();
            var path = CreateTemporaryFile(string.Empty);
            var processor = new CsvFileProcessor { Output = output };

            try
            {
                // Act
                processor.ProcessFile(path);

                // Assert
                Assert.DoesNotContain("Processed CSV line", output.ToString());
            }
            finally
            {
                File.Delete(path);
            }
        }

        private static string CreateTemporaryFile(string content)
        {
            var path = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.txt");
            File.WriteAllText(path, content);
            return path;
        }

        // A concrete subclass that records the template steps instead of touching the disk.
        // It exercises the real abstract base class rather than reimplementing the pattern.
        private sealed class RecordingFileProcessor : FileProcessor
        {
            private readonly List<string> _callOrder = new();

            public string Content { get; set; } = "default content";

            public IReadOnlyList<string> CallOrder => _callOrder;

            public string? ReceivedContent { get; private set; }

            protected override void OpenFile(string filePath)
            {
                _callOrder.Add("OpenFile");
            }

            protected override string ReadFileContent()
            {
                _callOrder.Add("ReadFileContent");
                return Content;
            }

            protected override void ProcessContent(string content)
            {
                _callOrder.Add("ProcessContent");
                ReceivedContent = content;
            }

            protected override void CloseFile()
            {
                _callOrder.Add("CloseFile");
            }
        }

        // A subclass that overrides only the mandatory steps, so that the default
        // implementations of OpenFile and CloseFile are the ones under test.
        private sealed class DefaultStepsFileProcessor : FileProcessor
        {
            protected override string ReadFileContent() => "content";

            protected override void ProcessContent(string content)
            {
            }
        }
    }
}
