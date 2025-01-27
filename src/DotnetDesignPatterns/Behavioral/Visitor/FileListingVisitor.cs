// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Concrete Visitor: File Listing
    public class FileListingVisitor : IFileSystemVisitor
    {
        public void Visit(File file)
        {
            Console.WriteLine($"File: {file.Name} - Size: {file.Size} bytes");
        }

        public void Visit(Directory directory)
        {
            Console.WriteLine($"Directory: {directory.Name}");
        }
    }
}
