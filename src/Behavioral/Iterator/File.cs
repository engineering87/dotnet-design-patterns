// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Iterator
{
    // Concrete Element: File
    public class File : IFileSystemElement
    {
        public string Name { get; }

        public File(string name)
        {
            Name = name;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"File: {Name}");
        }
    }
}
