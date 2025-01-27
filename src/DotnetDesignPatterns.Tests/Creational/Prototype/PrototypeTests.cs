// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Creational.Prototype;

namespace DotnetDesignPatterns.Tests.Creational.Prototype
{
    public class PrototypeTests
    {
        [Fact]
        public void Clone_ShouldCreateDeepCopy()
        {
            // Arrange
            var original = new OperatingSystemSettings("Windows", "10.0");

            // Act
            var clone = original.Clone();

            // Assert
            Assert.NotNull(clone);
            Assert.NotSame(original, clone);
            Assert.Equal(original.OSName, clone.OSName);
            Assert.Equal(original.Version, clone.Version);
        }

        [Fact]
        public void Clone_ModifyingCloneShouldNotAffectOriginal()
        {
            // Arrange
            var original = new OperatingSystemSettings("Linux", "5.0");
            var clone = original.Clone();

            // Act
            clone.OSName = "Ubuntu";
            clone.Version = "20.04";

            // Assert
            Assert.NotEqual(original.OSName, clone.OSName);
            Assert.NotEqual(original.Version, clone.Version);
            Assert.Equal("Linux", original.OSName);
            Assert.Equal("5.0", original.Version);
        }

        [Fact]
        public void DisplaySettings_ShouldOutputCorrectDetails()
        {
            // Arrange
            var settings = new OperatingSystemSettings("MacOS", "12.5");

            // Act
            var consoleOutput = CaptureConsoleOutput(() => settings.DisplaySettings());

            // Assert
            Assert.Contains("OS Name: MacOS", consoleOutput);
            Assert.Contains("Version: 12.5", consoleOutput);
        }

        // Helper method to capture console output
        private string CaptureConsoleOutput(Action action)
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                action.Invoke();
                return stringWriter.ToString();
            }
        }
    }
}
