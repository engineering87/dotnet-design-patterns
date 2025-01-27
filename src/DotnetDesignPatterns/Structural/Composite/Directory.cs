// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Composite
{
    // Composite
    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> _children = [];

        public Directory(string name) : base(name)
        {
        }

        public void Add(FileSystemComponent component)
        {
            _children.Add(component);
        }

        public void Remove(FileSystemComponent component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }

        public override long CalculateSize()
        {
            long totalSize = 0;
            foreach (var component in _children)
            {
                totalSize += component.CalculateSize();
            }
            return totalSize;
        }
    }
}
