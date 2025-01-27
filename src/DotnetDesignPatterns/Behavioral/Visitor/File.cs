// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Concrete Element: File
    public class File : IFileSystemElement
    {
        public string Name { get; }
        public long Size { get; }

        public File(string name, long size)
        {
            Name = name;
            Size = size;
        }

        public void Accept(IFileSystemVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
