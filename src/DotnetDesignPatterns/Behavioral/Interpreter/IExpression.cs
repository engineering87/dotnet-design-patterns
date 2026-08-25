// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Interpreter
{
    /// <summary>
    /// One rule of the grammar, able to decide whether a file matches.
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        /// Applies the rule to a file.
        /// </summary>
        /// <param name="file">The file being visited.</param>
        /// <returns>True when the file matches the rule.</returns>
        bool Interpret(File file);
    }
}
