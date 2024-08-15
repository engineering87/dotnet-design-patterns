// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Interpreter
{
    // Context
    public class File
    {
        public string Name { get; }
        public string Extension { get; }

        public File(string name, string extension)
        {
            Name = name;
            Extension = extension;
        }
    }
}
