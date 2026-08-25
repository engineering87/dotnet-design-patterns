// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Interpreter
{
    // Terminal Expression: ExtensionFilter
    /// <summary>
    /// A terminal expression that matches on the extension.
    /// </summary>
    public class ExtensionFilter : IExpression
    {
        private readonly string _extension;

        /// <summary>
        /// Creates a filter for one extension.
        /// </summary>
        /// <param name="extension">The extension the filter matches.</param>
        public ExtensionFilter(string extension)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(extension);

            _extension = extension;
        }

        /// <summary>
        /// Checks the extension of the file.
        /// </summary>
        /// <param name="file">The file being visited.</param>
        /// <returns>True when the extension matches.</returns>
        public bool Interpret(File file)
        {
            ArgumentNullException.ThrowIfNull(file);

            return file.Extension.Equals(_extension, StringComparison.OrdinalIgnoreCase);
        }
    }
}
