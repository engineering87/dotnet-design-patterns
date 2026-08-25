// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Facade
{
    // Subsystem 1: File Reader
    /// <summary>
    /// One of the subsystem classes the facade hides.
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Reads the file at the given path.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>The content of the file.</returns>
        public string ReadFile(string filePath)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

            Output.WriteLine($"Reading file from {filePath}");
            return "File content";
        }
    }
}
