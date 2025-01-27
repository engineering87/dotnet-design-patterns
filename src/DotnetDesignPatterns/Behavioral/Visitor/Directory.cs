// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Concrete Element: Directory
    public class Directory : IFileSystemElement
    {
        public string Name { get; }
        public List<IFileSystemElement> Elements { get; }

        public Directory(string name)
        {
            Name = name;
            Elements = new List<IFileSystemElement>();
        }

        public void AddElement(IFileSystemElement element)
        {
            Elements.Add(element);
        }

        public void Accept(IFileSystemVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var element in Elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
