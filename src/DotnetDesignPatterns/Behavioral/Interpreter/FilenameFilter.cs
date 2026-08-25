// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Collections.Generic;
// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Interpreter
{
    // Terminal Expression: FilenameFilter
    /// <summary>
    /// A terminal expression that matches on the name.
    /// </summary>
    public class FilenameFilter : IExpression
    {
        private readonly string _filename;

        /// <summary>
        /// Creates a filter for one name.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public FilenameFilter(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            _filename = filename;
        }

        /// <summary>
        /// Checks the name of the file.
        /// </summary>
        /// <param name="file">The file being visited.</param>
        /// <returns>True when the name matches.</returns>
        public bool Interpret(File file)
        {
            ArgumentNullException.ThrowIfNull(file);

            return file.Name.Contains(_filename, StringComparison.OrdinalIgnoreCase);
        }
    }
}
