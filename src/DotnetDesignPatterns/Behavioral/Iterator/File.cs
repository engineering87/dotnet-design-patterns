// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Iterator
{
    // Concrete Element: File
    /// <summary>
    /// A file that an iterator can return.
    /// </summary>
    public class File : IFileSystemElement
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// The name of the file.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Creates a named file.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        public File(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Name = name;
        }

        /// <summary>
        /// Writes a short description of the file.
        /// </summary>
        public void PrintDetails()
        {
            Output.WriteLine($"File: {Name}");
        }
    }
}
