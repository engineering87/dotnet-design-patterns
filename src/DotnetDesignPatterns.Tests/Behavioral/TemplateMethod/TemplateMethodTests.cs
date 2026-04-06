// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)

namespace DotnetDesignPatterns.Tests.Behavioral.TemplateMethod
{
    public class TemplateMethodTests
    {
        [Fact]
        public void TestFileProcessor_ProcessFile_ShouldFollowTemplateOrder()
        {
            // Arrange
            var processor = new TestFileProcessor();
            var callOrder = new List<string>();
            processor.OnOpenFile = () => callOrder.Add("OpenFile");
            processor.OnReadFileContent = () => { callOrder.Add("ReadFileContent"); return "test content"; };
            processor.OnProcessContent = () => callOrder.Add("ProcessContent");
            processor.OnCloseFile = () => callOrder.Add("CloseFile");

            // Act
            processor.ProcessFile("test.txt");

            // Assert
            Assert.Equal(4, callOrder.Count);
            Assert.Equal("OpenFile", callOrder[0]);
            Assert.Equal("ReadFileContent", callOrder[1]);
            Assert.Equal("ProcessContent", callOrder[2]);
            Assert.Equal("CloseFile", callOrder[3]);
        }

        [Fact]
        public void TestFileProcessor_OpenFile_ShouldBeOverridable()
        {
            // Arrange
            var customOpenFileCalled = false;
            var processor = new TestFileProcessor
            {
                OnOpenFile = () => customOpenFileCalled = true
            };

            // Act
            processor.ProcessFile("test.txt");

            // Assert
            Assert.True(customOpenFileCalled);
        }

        [Fact]
        public void TestFileProcessor_CloseFile_ShouldBeOverridable()
        {
            // Arrange
            var customCloseFileCalled = false;
            var processor = new TestFileProcessor
            {
                OnCloseFile = () => customCloseFileCalled = true
            };

            // Act
            processor.ProcessFile("test.txt");

            // Assert
            Assert.True(customCloseFileCalled);
        }

        [Fact]
        public void TestFileProcessor_ReadFileContent_ShouldReturnContent()
        {
            // Arrange
            var expectedContent = "Expected file content";
            var processor = new TestFileProcessor
            {
                OnReadFileContent = () => expectedContent
            };
            string? actualContent = null;
            processor.OnProcessContent = () => actualContent = processor.LastReadContent;

            // Act
            processor.ProcessFile("test.txt");

            // Assert
            Assert.Equal(expectedContent, actualContent);
        }

        [Fact]
        public void TestFileProcessor_ProcessContent_ShouldReceiveReadContent()
        {
            // Arrange
            var processor = new TestFileProcessor();
            var contentToProcess = "Content to be processed";
            processor.OnReadFileContent = () => contentToProcess;
            string? processedContent = null;
            processor.OnProcessContent = () => processedContent = processor.LastReadContent;

            // Act
            processor.ProcessFile("test.txt");

            // Assert
            Assert.Equal(contentToProcess, processedContent);
        }

        private class TestFileProcessor
        {
            public Action? OnOpenFile { get; set; }
            public Func<string>? OnReadFileContent { get; set; }
            public Action? OnProcessContent { get; set; }
            public Action? OnCloseFile { get; set; }
            public string? LastReadContent { get; private set; }

            public void ProcessFile(string filePath)
            {
                OpenFile(filePath);
                LastReadContent = ReadFileContent();
                ProcessContent(LastReadContent);
                CloseFile();
            }

            private void OpenFile(string filePath)
            {
                if (OnOpenFile != null)
                    OnOpenFile();
                else
                    Console.WriteLine($"Opening file: {filePath}");
            }

            private string ReadFileContent()
            {
                if (OnReadFileContent != null)
                    return OnReadFileContent();
                return "default content";
            }

            private void ProcessContent(string content)
            {
                OnProcessContent?.Invoke();
            }

            private void CloseFile()
            {
                if (OnCloseFile != null)
                    OnCloseFile();
                else
                    Console.WriteLine("Closing file.");
            }
        }
    }
}
