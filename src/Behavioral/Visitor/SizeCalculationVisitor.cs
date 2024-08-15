// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Concrete Visitor: Size Calculation
    public class SizeCalculationVisitor : IFileSystemVisitor
    {
        public long TotalSize { get; private set; }

        public void Visit(File file)
        {
            TotalSize += file.Size;
        }

        public void Visit(Directory directory)
        {
            // Optionally, do something with the directory
        }
    }
}
