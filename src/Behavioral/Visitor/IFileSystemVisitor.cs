// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Visitor Interface
    public interface IFileSystemVisitor
    {
        void Visit(File file);
        void Visit(Directory directory);
    }
}
