// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Interpreter
{
    // Terminal Expression: ExtensionFilter
    public class ExtensionFilter : IExpression
    {
        private readonly string _extension;

        public ExtensionFilter(string extension)
        {
            _extension = extension;
        }

        public bool Interpret(File file)
        {
            return file.Extension.Equals(_extension, StringComparison.OrdinalIgnoreCase);
        }
    }
}
