// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Structural.Flyweight;

namespace DotnetDesignPatterns.Tests.Structural.Flyweight
{
    public class FlyweightTests
    {
        [Fact]
        public void FileMetadataFactory_GetFileMetadata_ShouldCreateNewMetadata()
        {
            // Arrange
            var factory = new FileMetadataFactory();

            // Act
            var output = CaptureConsoleOutput(() => factory.GetFileMetadata("pdf", "admin"));

            // Assert
            Assert.Contains("Creating new file metadata", output);
        }

        [Fact]
        public void FileMetadataFactory_GetFileMetadata_ShouldReturnSameInstanceForSameKey()
        {
            // Arrange
            var factory = new FileMetadataFactory();

            // Act
            var metadata1 = factory.GetFileMetadata("pdf", "admin");
            var metadata2 = factory.GetFileMetadata("pdf", "admin");

            // Assert
            Assert.Same(metadata1, metadata2);
        }

        [Fact]
        public void FileMetadataFactory_GetFileMetadata_ShouldReuseCachedMetadata()
        {
            // Arrange
            var factory = new FileMetadataFactory();
            factory.GetFileMetadata("txt", "user1");

            // Act
            var output = CaptureConsoleOutput(() => factory.GetFileMetadata("txt", "user1"));

            // Assert
            Assert.Contains("Reusing existing file metadata", output);
        }

        [Fact]
        public void FileMetadataFactory_GetFileMetadata_ShouldCreateDifferentInstancesForDifferentKeys()
        {
            // Arrange
            var factory = new FileMetadataFactory();

            // Act
            var metadata1 = factory.GetFileMetadata("pdf", "admin");
            var metadata2 = factory.GetFileMetadata("txt", "admin");
            var metadata3 = factory.GetFileMetadata("pdf", "user");

            // Assert
            Assert.NotSame(metadata1, metadata2);
            Assert.NotSame(metadata1, metadata3);
            Assert.NotSame(metadata2, metadata3);
        }

        [Fact]
        public void FileMetadataFactory_GetFileMetadata_WithNullFileType_ShouldThrowArgumentNullException()
        {
            // Arrange
            var factory = new FileMetadataFactory();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => factory.GetFileMetadata(null!, "admin"));
        }

        [Fact]
        public void FileMetadataFactory_GetFileMetadata_WithEmptyFileType_ShouldThrowArgumentException()
        {
            // Arrange
            var factory = new FileMetadataFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.GetFileMetadata("", "admin"));
            Assert.Throws<ArgumentException>(() => factory.GetFileMetadata("   ", "admin"));
        }

        [Fact]
        public void FileMetadataFactory_GetFileMetadata_WithNullOwner_ShouldThrowArgumentNullException()
        {
            // Arrange
            var factory = new FileMetadataFactory();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => factory.GetFileMetadata("pdf", null!));
        }

        [Fact]
        public void FileMetadataFactory_GetFileMetadata_WithEmptyOwner_ShouldThrowArgumentException()
        {
            // Arrange
            var factory = new FileMetadataFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.GetFileMetadata("pdf", ""));
            Assert.Throws<ArgumentException>(() => factory.GetFileMetadata("pdf", "   "));
        }

        [Fact]
        public void FileMetadataFactory_CacheCount_ShouldReflectUniqueEntries()
        {
            // Arrange
            var factory = new FileMetadataFactory();

            // Act
            factory.GetFileMetadata("pdf", "admin");
            factory.GetFileMetadata("txt", "admin");
            factory.GetFileMetadata("pdf", "admin"); // duplicate
            factory.GetFileMetadata("doc", "user");

            // Assert
            Assert.Equal(3, factory.CacheCount);
        }

        [Fact]
        public void FileMetadata_DisplayFileInfo_ShouldOutputCorrectInfo()
        {
            // Arrange
            var factory = new FileMetadataFactory();
            var metadata = factory.GetFileMetadata("xlsx", "finance");

            // Act
            var output = CaptureConsoleOutput(() => metadata.DisplayFileInfo());

            // Assert
            Assert.Contains("xlsx", output);
            Assert.Contains("finance", output);
        }

        [Fact]
        public void FileMetadataFactory_ShouldBeThreadSafe()
        {
            // Arrange
            var factory = new FileMetadataFactory();
            var tasks = new List<Task<IFileMetadata>>();

            // Act - Create many concurrent requests for the same key
            for (int i = 0; i < 100; i++)
            {
                tasks.Add(Task.Run(() => factory.GetFileMetadata("pdf", "admin")));
            }

            Task.WaitAll(tasks.ToArray());

            // Assert - All should return the same instance
            var firstResult = tasks[0].Result;
            Assert.All(tasks, t => Assert.Same(firstResult, t.Result));
            Assert.Equal(1, factory.CacheCount);
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
