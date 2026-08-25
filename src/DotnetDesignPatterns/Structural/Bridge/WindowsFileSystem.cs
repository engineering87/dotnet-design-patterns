// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Bridge
{
    /// <summary>
    /// The Windows implementation behind the bridge.
    /// </summary>
    public class WindowsFileSystem : IFileSystem
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Writes the content the Windows way.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="content">The content to write.</param>
        public void WriteToFile(string fileName, string content)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

            Output.WriteLine($"Writing to Windows file: {fileName}");
            // Windows-specific file writing logic
        }

        /// <summary>
        /// Reads the file the Windows way.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The content of the file.</returns>
        public string ReadFromFile(string fileName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

            Output.WriteLine($"Reading from Windows file: {fileName}");
            // Windows-specific file reading logic
            return "File content from Windows";
        }
    }
}
