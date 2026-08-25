// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Concrete Visitor: File Listing
    /// <summary>
    /// A visitor that writes the name of everything it walks.
    /// </summary>
    public class FileListingVisitor : IFileSystemVisitor
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Writes the name of the file.
        /// </summary>
        /// <param name="file">The file being visited.</param>
        public void Visit(File file)
        {
            ArgumentNullException.ThrowIfNull(file);

            Output.WriteLine($"File: {file.Name} - Size: {file.Size} bytes");
        }

        /// <summary>
        /// Writes the name of the directory and walks into it.
        /// </summary>
        /// <param name="directory">The directory being visited.</param>
        public void Visit(Directory directory)
        {
            ArgumentNullException.ThrowIfNull(directory);

            Output.WriteLine($"Directory: {directory.Name}");
        }
    }
}
