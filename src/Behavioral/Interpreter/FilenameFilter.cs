using System;
using System.Collections.Generic;
// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Interpreter
{
    // Terminal Expression: FilenameFilter
    public class FilenameFilter : IExpression
    {
        private readonly string _filename;

        public FilenameFilter(string filename)
        {
            _filename = filename;
        }

        public bool Interpret(File file)
        {
            return file.Name.Contains(_filename, StringComparison.OrdinalIgnoreCase);
        }
    }
}
