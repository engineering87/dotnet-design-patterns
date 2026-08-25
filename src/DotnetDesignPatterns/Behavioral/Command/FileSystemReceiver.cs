// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    // Receiver Class: Represents the file system
    /// <summary>
    /// The receiver. It knows how to do the work, and nothing about commands.
    /// </summary>
    public class FileSystemReceiver
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Creates the named file.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public void CreateFile(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            Output.WriteLine($"Creating file: {filename}");
        }

        /// <summary>
        /// Writes the content to the named file.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        /// <param name="content">The content to write.</param>
        public void WriteFile(string filename, string content)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);
            ArgumentNullException.ThrowIfNull(content);

            Output.WriteLine($"Writing to file: {filename}");
            Output.WriteLine($"Content: {content}");
        }

        /// <summary>
        /// Deletes the named file.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public void DeleteFile(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            Output.WriteLine($"Deleting file: {filename}");
        }
    }
}
