// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using Directory = DotnetDesignPatterns.Behavioral.Iterator.Directory;
using File = DotnetDesignPatterns.Behavioral.Iterator.File;

namespace DotnetDesignPatterns.Tests.Behavioral.Iterator
{
    public class IteratorTests
    {
        [Fact]
        public void Directory_CreateIterator_ShouldReturnIterator()
        {
            // Arrange
            var directory = new Directory("TestDir");

            // Act
            var iterator = directory.CreateIterator();

            // Assert
            Assert.NotNull(iterator);
        }

        [Fact]
        public void Iterator_HasNext_EmptyDirectory_ShouldReturnFalse()
        {
            // Arrange
            var directory = new Directory("EmptyDir");
            var iterator = directory.CreateIterator();

            // Act & Assert
            Assert.False(iterator.HasNext());
        }

        [Fact]
        public void Iterator_HasNext_WithElements_ShouldReturnTrue()
        {
            // Arrange
            var directory = new Directory("TestDir");
            directory.AddElement(new File("test.txt"));
            var iterator = directory.CreateIterator();

            // Act & Assert
            Assert.True(iterator.HasNext());
        }

        [Fact]
        public void Iterator_Next_ShouldReturnElements()
        {
            // Arrange
            var directory = new Directory("TestDir");
            var file1 = new File("file1.txt");
            var file2 = new File("file2.txt");
            directory.AddElement(file1);
            directory.AddElement(file2);
            var iterator = directory.CreateIterator();

            // Act
            var first = iterator.Next();
            var second = iterator.Next();

            // Assert
            Assert.Same(file1, first);
            Assert.Same(file2, second);
        }

        [Fact]
        public void Iterator_Next_WhenNoMoreElements_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var directory = new Directory("TestDir");
            directory.AddElement(new File("test.txt"));
            var iterator = directory.CreateIterator();
            iterator.Next();

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => iterator.Next());
            Assert.Contains("No more elements", exception.Message);
        }

        [Fact]
        public void Iterator_ShouldIterateThroughAllElements()
        {
            // Arrange
            var directory = new Directory("TestDir");
            directory.AddElement(new File("file1.txt"));
            directory.AddElement(new File("file2.txt"));
            directory.AddElement(new File("file3.txt"));
            var iterator = directory.CreateIterator();
            var count = 0;

            // Act
            while (iterator.HasNext())
            {
                iterator.Next();
                count++;
            }

            // Assert
            Assert.Equal(3, count);
        }

        [Fact]
        public void File_PrintDetails_ShouldOutputFileName()
        {
            // Arrange
            var file = new File("document.pdf");

            // Act
            var output = CaptureConsoleOutput(() => file.PrintDetails());

            // Assert
            Assert.Contains("document.pdf", output);
        }

        [Fact]
        public void Directory_PrintDetails_ShouldOutputDirectoryName()
        {
            // Arrange
            var directory = new Directory("MyFolder");

            // Act
            var output = CaptureConsoleOutput(() => directory.PrintDetails());

            // Assert
            Assert.Contains("MyFolder", output);
        }

        [Fact]
        public void Directory_AddElement_ShouldAddToCollection()
        {
            // Arrange
            var directory = new Directory("TestDir");
            var file = new File("test.txt");

            // Act
            directory.AddElement(file);
            var iterator = directory.CreateIterator();

            // Assert
            Assert.True(iterator.HasNext());
            Assert.Same(file, iterator.Next());
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
