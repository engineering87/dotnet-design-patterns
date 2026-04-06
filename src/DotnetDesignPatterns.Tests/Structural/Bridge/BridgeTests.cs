// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Structural.Bridge;

namespace DotnetDesignPatterns.Tests.Structural.Bridge
{
    public class BridgeTests
    {
        [Fact]
        public void TextFileManager_SaveFile_WithWindowsFileSystem_ShouldUseWindowsImplementation()
        {
            // Arrange
            var windowsFileSystem = new WindowsFileSystem();
            var fileManager = new TextFileManager(windowsFileSystem);

            // Act
            var output = CaptureConsoleOutput(() => fileManager.SaveFile("test.txt", "Hello World"));

            // Assert
            Assert.Contains("Windows", output);
            Assert.Contains("test.txt", output);
        }

        [Fact]
        public void TextFileManager_SaveFile_WithLinuxFileSystem_ShouldUseLinuxImplementation()
        {
            // Arrange
            var linuxFileSystem = new LinuxFileSystem();
            var fileManager = new TextFileManager(linuxFileSystem);

            // Act
            var output = CaptureConsoleOutput(() => fileManager.SaveFile("test.txt", "Hello World"));

            // Assert
            Assert.Contains("Linux", output);
            Assert.Contains("test.txt", output);
        }

        [Fact]
        public void TextFileManager_ReadFile_WithWindowsFileSystem_ShouldReturnWindowsContent()
        {
            // Arrange
            var windowsFileSystem = new WindowsFileSystem();
            var fileManager = new TextFileManager(windowsFileSystem);

            // Act
            var content = fileManager.ReadFile("test.txt");

            // Assert
            Assert.NotNull(content);
            Assert.Contains("Windows", content);
        }

        [Fact]
        public void TextFileManager_ReadFile_WithLinuxFileSystem_ShouldReturnLinuxContent()
        {
            // Arrange
            var linuxFileSystem = new LinuxFileSystem();
            var fileManager = new TextFileManager(linuxFileSystem);

            // Act
            var content = fileManager.ReadFile("test.txt");

            // Assert
            Assert.NotNull(content);
            Assert.Contains("Linux", content);
        }

        [Fact]
        public void WindowsFileSystem_WriteToFile_ShouldOutputCorrectMessage()
        {
            // Arrange
            var fileSystem = new WindowsFileSystem();

            // Act
            var output = CaptureConsoleOutput(() => fileSystem.WriteToFile("document.pdf", "content"));

            // Assert
            Assert.Contains("Writing to Windows file", output);
            Assert.Contains("document.pdf", output);
        }

        [Fact]
        public void LinuxFileSystem_WriteToFile_ShouldOutputCorrectMessage()
        {
            // Arrange
            var fileSystem = new LinuxFileSystem();

            // Act
            var output = CaptureConsoleOutput(() => fileSystem.WriteToFile("document.pdf", "content"));

            // Assert
            Assert.Contains("Writing to Linux file", output);
            Assert.Contains("document.pdf", output);
        }

        [Fact]
        public void WindowsFileSystem_ReadFromFile_ShouldOutputCorrectMessage()
        {
            // Arrange
            var fileSystem = new WindowsFileSystem();

            // Act
            var output = CaptureConsoleOutput(() => fileSystem.ReadFromFile("report.txt"));

            // Assert
            Assert.Contains("Reading from Windows file", output);
            Assert.Contains("report.txt", output);
        }

        [Fact]
        public void LinuxFileSystem_ReadFromFile_ShouldOutputCorrectMessage()
        {
            // Arrange
            var fileSystem = new LinuxFileSystem();

            // Act
            var output = CaptureConsoleOutput(() => fileSystem.ReadFromFile("report.txt"));

            // Assert
            Assert.Contains("Reading from Linux file", output);
            Assert.Contains("report.txt", output);
        }

        [Fact]
        public void FileManager_CanSwitchFileSystemAtRuntime()
        {
            // Arrange
            var windowsFs = new WindowsFileSystem();
            var linuxFs = new LinuxFileSystem();
            var windowsManager = new TextFileManager(windowsFs);
            var linuxManager = new TextFileManager(linuxFs);

            // Act
            var windowsContent = windowsManager.ReadFile("test.txt");
            var linuxContent = linuxManager.ReadFile("test.txt");

            // Assert
            Assert.Contains("Windows", windowsContent);
            Assert.Contains("Linux", linuxContent);
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
