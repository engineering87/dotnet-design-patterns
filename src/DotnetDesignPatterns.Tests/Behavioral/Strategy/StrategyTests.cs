// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Behavioral.Strategy;

namespace DotnetDesignPatterns.Tests.Behavioral.Strategy
{
    public class StrategyTests
    {
        [Fact]
        public void FileCompressor_SetCompressionStrategy_ShouldSetStrategy()
        {
            // Arrange
            var compressor = new FileCompressor();
            var strategy = new MockCompressionStrategy();

            // Act & Assert
            var exception = Record.Exception(() => compressor.SetCompressionStrategy(strategy));
            Assert.Null(exception);
        }

        [Fact]
        public void FileCompressor_SetCompressionStrategy_WithNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var compressor = new FileCompressor();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => compressor.SetCompressionStrategy(null!));
        }

        [Fact]
        public void FileCompressor_CompressFile_WithoutStrategy_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var compressor = new FileCompressor();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => compressor.CompressFile("test.txt"));
        }

        [Fact]
        public void FileCompressor_CompressFile_WithNullPath_ShouldThrowArgumentNullException()
        {
            // Arrange
            var compressor = new FileCompressor();
            compressor.SetCompressionStrategy(new MockCompressionStrategy());

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => compressor.CompressFile(null!));
        }

        [Fact]
        public void FileCompressor_CompressFile_WithEmptyPath_ShouldThrowArgumentException()
        {
            // Arrange
            var compressor = new FileCompressor();
            compressor.SetCompressionStrategy(new MockCompressionStrategy());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => compressor.CompressFile(""));
            Assert.Throws<ArgumentException>(() => compressor.CompressFile("   "));
        }

        [Fact]
        public void FileCompressor_CompressFile_WithStrategy_ShouldCallCompress()
        {
            // Arrange
            var compressor = new FileCompressor();
            var strategy = new MockCompressionStrategy();
            compressor.SetCompressionStrategy(strategy);

            // Act
            compressor.CompressFile("test.txt");

            // Assert
            Assert.True(strategy.WasCalled);
            Assert.Equal("test.txt", strategy.LastFilePath);
        }

        [Fact]
        public void FileCompressor_CanChangeStrategy_AtRuntime()
        {
            // Arrange
            var compressor = new FileCompressor();
            var strategy1 = new MockCompressionStrategy();
            var strategy2 = new MockCompressionStrategy();

            // Act
            compressor.SetCompressionStrategy(strategy1);
            compressor.CompressFile("file1.txt");
            compressor.SetCompressionStrategy(strategy2);
            compressor.CompressFile("file2.txt");

            // Assert
            Assert.True(strategy1.WasCalled);
            Assert.Equal("file1.txt", strategy1.LastFilePath);
            Assert.True(strategy2.WasCalled);
            Assert.Equal("file2.txt", strategy2.LastFilePath);
        }

        private class MockCompressionStrategy : ICompressionStrategy
        {
            public bool WasCalled { get; private set; }
            public string? LastFilePath { get; private set; }

            public void Compress(string filePath)
            {
                WasCalled = true;
                LastFilePath = filePath;
            }
        }
    }
}
