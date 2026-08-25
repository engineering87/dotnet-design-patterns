// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Interpreter
{
    /// <summary>
    /// The context an expression is interpreted against.
    /// </summary>
    public class File
    {
        /// <summary>
        /// The name of the file.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The extension of the file.
        /// </summary>
        public string Extension { get; }

        /// <summary>
        /// Creates the file description the filters read.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="extension">The extension the filter matches.</param>
        public File(string name, string extension)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(extension);

            Name = name;
            Extension = extension;
        }
    }
}
