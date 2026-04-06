// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using File = DotnetDesignPatterns.Structural.Composite.File;
using Directory = DotnetDesignPatterns.Structural.Composite.Directory;

namespace DotnetDesignPatterns.Tests.Structural.Composite
{
    public class CompositeTests
    {
        [Fact]
        public void File_CalculateSize_ShouldReturnFileSize()
        {
            // Arrange
            var file = new File("test.txt", 1024);

            // Act
            var size = file.CalculateSize();

            // Assert
            Assert.Equal(1024, size);
        }

        [Fact]
        public void File_Display_ShouldOutputFileName()
        {
            // Arrange
            var file = new File("document.pdf", 2048);

            // Act
            var output = CaptureConsoleOutput(() => file.Display(2));

            // Assert
            Assert.Contains("document.pdf", output);
        }

        [Fact]
        public void Directory_CalculateSize_EmptyDirectory_ShouldReturnZero()
        {
            // Arrange
            var directory = new Directory("EmptyFolder");

            // Act
            var size = directory.CalculateSize();

            // Assert
            Assert.Equal(0, size);
        }

        [Fact]
        public void Directory_CalculateSize_WithFiles_ShouldReturnTotalSize()
        {
            // Arrange
            var directory = new Directory("Documents");
            directory.Add(new File("file1.txt", 100));
            directory.Add(new File("file2.txt", 200));
            directory.Add(new File("file3.txt", 300));

            // Act
            var size = directory.CalculateSize();

            // Assert
            Assert.Equal(600, size);
        }

        [Fact]
        public void Directory_CalculateSize_NestedDirectories_ShouldReturnTotalSize()
        {
            // Arrange
            var rootDirectory = new Directory("Root");
            var subDirectory = new Directory("SubFolder");
            subDirectory.Add(new File("nested.txt", 150));
            rootDirectory.Add(new File("root.txt", 100));
            rootDirectory.Add(subDirectory);

            // Act
            var size = rootDirectory.CalculateSize();

            // Assert
            Assert.Equal(250, size);
        }

        [Fact]
        public void Directory_Add_ShouldAddComponent()
        {
            // Arrange
            var directory = new Directory("TestDir");
            var file = new File("test.txt", 100);

            // Act
            directory.Add(file);
            var size = directory.CalculateSize();

            // Assert
            Assert.Equal(100, size);
        }

        [Fact]
        public void Directory_Remove_ShouldRemoveComponent()
        {
            // Arrange
            var directory = new Directory("TestDir");
            var file = new File("test.txt", 100);
            directory.Add(file);

            // Act
            directory.Remove(file);
            var size = directory.CalculateSize();

            // Assert
            Assert.Equal(0, size);
        }

        [Fact]
        public void Directory_Display_ShouldOutputDirectoryAndChildren()
        {
            // Arrange
            var directory = new Directory("Documents");
            directory.Add(new File("file1.txt", 100));
            directory.Add(new File("file2.txt", 200));

            // Act
            var output = CaptureConsoleOutput(() => directory.Display(0));

            // Assert
            Assert.Contains("Documents", output);
            Assert.Contains("file1.txt", output);
            Assert.Contains("file2.txt", output);
        }

        [Fact]
        public void Directory_Display_NestedStructure_ShouldShowHierarchy()
        {
            // Arrange
            var root = new Directory("Root");
            var docs = new Directory("Documents");
            docs.Add(new File("readme.txt", 50));
            root.Add(docs);
            root.Add(new File("config.xml", 30));

            // Act
            var output = CaptureConsoleOutput(() => root.Display(0));

            // Assert
            Assert.Contains("Root", output);
            Assert.Contains("Documents", output);
            Assert.Contains("readme.txt", output);
            Assert.Contains("config.xml", output);
        }

        [Fact]
        public void FileSystemComponent_Name_ShouldBeAccessible()
        {
            // Arrange
            var file = new File("myfile.txt", 100);
            var directory = new Directory("mydir");

            // Assert
            Assert.Equal("myfile.txt", file.Name);
            Assert.Equal("mydir", directory.Name);
        }

        [Fact]
        public void DeepNestedStructure_CalculateSize_ShouldCalculateCorrectly()
        {
            // Arrange
            var root = new Directory("Root");
            var level1 = new Directory("Level1");
            var level2 = new Directory("Level2");
            var level3 = new Directory("Level3");

            level3.Add(new File("deep.txt", 100));
            level2.Add(level3);
            level2.Add(new File("mid.txt", 50));
            level1.Add(level2);
            level1.Add(new File("upper.txt", 25));
            root.Add(level1);
            root.Add(new File("root.txt", 10));

            // Act
            var size = root.CalculateSize();

            // Assert
            Assert.Equal(185, size); // 100 + 50 + 25 + 10 = 185
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
