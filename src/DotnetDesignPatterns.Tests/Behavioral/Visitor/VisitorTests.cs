// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.Visitor;
using Directory = DotnetDesignPatterns.Behavioral.Visitor.Directory;
using File = DotnetDesignPatterns.Behavioral.Visitor.File;

namespace DotnetDesignPatterns.Tests.Behavioral.Visitor
{
    public class VisitorTests
    {
        [Fact]
        public void SizeCalculationVisitor_Visit_File_ShouldAddFileSize()
        {
            // Arrange
            var visitor = new SizeCalculationVisitor();
            var file = new File("test.txt", 1024);

            // Act
            visitor.Visit(file);

            // Assert
            Assert.Equal(1024, visitor.TotalSize);
        }

        [Fact]
        public void SizeCalculationVisitor_Visit_MultipleFiles_ShouldSumSizes()
        {
            // Arrange
            var visitor = new SizeCalculationVisitor();
            var file1 = new File("file1.txt", 100);
            var file2 = new File("file2.txt", 200);
            var file3 = new File("file3.txt", 300);

            // Act
            visitor.Visit(file1);
            visitor.Visit(file2);
            visitor.Visit(file3);

            // Assert
            Assert.Equal(600, visitor.TotalSize);
        }

        [Fact]
        public void SizeCalculationVisitor_InitialTotalSize_ShouldBeZero()
        {
            // Arrange & Act
            var visitor = new SizeCalculationVisitor();

            // Assert
            Assert.Equal(0, visitor.TotalSize);
        }

        [Fact]
        public void FileListingVisitor_Visit_File_ShouldOutputFileInfo()
        {
            // Arrange
            var visitor = new FileListingVisitor();
            var file = new File("document.pdf", 2048);

            // Act
            var output = CaptureConsoleOutput(() => visitor.Visit(file));

            // Assert
            Assert.Contains("document.pdf", output);
            Assert.Contains("2048", output);
        }

        [Fact]
        public void FileListingVisitor_Visit_Directory_ShouldOutputDirectoryName()
        {
            // Arrange
            var visitor = new FileListingVisitor();
            var directory = new Directory("MyFolder");

            // Act
            var output = CaptureConsoleOutput(() => visitor.Visit(directory));

            // Assert
            Assert.Contains("MyFolder", output);
        }

        [Fact]
        public void File_Accept_ShouldCallVisitorVisit()
        {
            // Arrange
            var visitor = new SizeCalculationVisitor();
            var file = new File("test.txt", 512);

            // Act
            file.Accept(visitor);

            // Assert
            Assert.Equal(512, visitor.TotalSize);
        }

        [Fact]
        public void Directory_Accept_ShouldVisitDirectoryAndAllElements()
        {
            // Arrange
            var visitor = new SizeCalculationVisitor();
            var directory = new Directory("Root");
            directory.AddElement(new File("file1.txt", 100));
            directory.AddElement(new File("file2.txt", 200));

            // Act
            directory.Accept(visitor);

            // Assert
            Assert.Equal(300, visitor.TotalSize);
        }

        [Fact]
        public void Directory_Accept_NestedDirectories_ShouldVisitAllElements()
        {
            // Arrange
            var visitor = new SizeCalculationVisitor();
            var rootDir = new Directory("Root");
            var subDir = new Directory("SubFolder");
            subDir.AddElement(new File("nested.txt", 150));
            rootDir.AddElement(new File("root.txt", 100));
            rootDir.AddElement(subDir);

            // Act
            rootDir.Accept(visitor);

            // Assert
            Assert.Equal(250, visitor.TotalSize);
        }

        [Fact]
        public void Directory_AddElement_ShouldAddToElements()
        {
            // Arrange
            var directory = new Directory("TestDir");
            var file = new File("test.txt", 100);

            // Act
            directory.AddElement(file);

            // Assert
            Assert.Contains(file, directory.Elements);
        }

        [Fact]
        public void File_Properties_ShouldReturnCorrectValues()
        {
            // Arrange & Act
            var file = new File("test.txt", 1024);

            // Assert
            Assert.Equal("test.txt", file.Name);
            Assert.Equal(1024, file.Size);
        }

        [Fact]
        public void Directory_Properties_ShouldReturnCorrectValues()
        {
            // Arrange & Act
            var directory = new Directory("MyFolder");

            // Assert
            Assert.Equal("MyFolder", directory.Name);
            Assert.NotNull(directory.Elements);
            Assert.Empty(directory.Elements);
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
