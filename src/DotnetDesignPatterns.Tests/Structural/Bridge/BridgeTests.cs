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
            var output = new StringWriter();
            var windowsFileSystem = new WindowsFileSystem { Output = output };
            var fileManager = new TextFileManager(windowsFileSystem);

            // Act
            fileManager.SaveFile("test.txt", "Hello World");

            // Assert
            Assert.Contains("Windows", output.ToString());
            Assert.Contains("test.txt", output.ToString());
        }

        [Fact]
        public void TextFileManager_SaveFile_WithLinuxFileSystem_ShouldUseLinuxImplementation()
        {
            // Arrange
            var output = new StringWriter();
            var linuxFileSystem = new LinuxFileSystem { Output = output };
            var fileManager = new TextFileManager(linuxFileSystem);

            // Act
            fileManager.SaveFile("test.txt", "Hello World");

            // Assert
            Assert.Contains("Linux", output.ToString());
            Assert.Contains("test.txt", output.ToString());
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
            var output = new StringWriter();
            var fileSystem = new WindowsFileSystem { Output = output };

            // Act
            fileSystem.WriteToFile("document.pdf", "content");

            // Assert
            Assert.Contains("Writing to Windows file", output.ToString());
            Assert.Contains("document.pdf", output.ToString());
        }

        [Fact]
        public void LinuxFileSystem_WriteToFile_ShouldOutputCorrectMessage()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new LinuxFileSystem { Output = output };

            // Act
            fileSystem.WriteToFile("document.pdf", "content");

            // Assert
            Assert.Contains("Writing to Linux file", output.ToString());
            Assert.Contains("document.pdf", output.ToString());
        }

        [Fact]
        public void WindowsFileSystem_ReadFromFile_ShouldOutputCorrectMessage()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new WindowsFileSystem { Output = output };

            // Act
            fileSystem.ReadFromFile("report.txt");

            // Assert
            Assert.Contains("Reading from Windows file", output.ToString());
            Assert.Contains("report.txt", output.ToString());
        }

        [Fact]
        public void LinuxFileSystem_ReadFromFile_ShouldOutputCorrectMessage()
        {
            // Arrange
            var output = new StringWriter();
            var fileSystem = new LinuxFileSystem { Output = output };

            // Act
            fileSystem.ReadFromFile("report.txt");

            // Assert
            Assert.Contains("Reading from Linux file", output.ToString());
            Assert.Contains("report.txt", output.ToString());
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

    }
}
