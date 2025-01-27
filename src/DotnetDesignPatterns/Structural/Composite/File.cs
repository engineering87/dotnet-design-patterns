// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Composite
{
    // Leaf
    public class File : FileSystemComponent
    {
        private long _size; // Size of the file in bytes

        public File(string name, long size) : base(name)
        {
            _size = size;
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
        }

        public override long CalculateSize()
        {
            return _size;
        }
    }
}
