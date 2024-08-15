// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Composite
{
    public abstract class FileSystemComponent
    {
        public string Name { get; protected set; }

        protected FileSystemComponent(string name)
        {
            Name = name;
        }

        public abstract void Display(int depth);
        public abstract long CalculateSize();
    }
}
