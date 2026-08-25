// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Facade
{
    // Subsystem 2: File Writer
    /// <summary>
    /// One of the subsystem classes the facade hides.
    /// </summary>
    public class FileWriter
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Writes the content to the given path.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <param name="content">The content to write.</param>
        public void WriteFile(string filePath, string content)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

            Output.WriteLine($"Writing to file at {filePath}");
        }
    }
}
