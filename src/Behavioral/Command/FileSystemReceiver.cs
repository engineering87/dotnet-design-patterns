// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    // Receiver Class: Represents the file system
    public class FileSystemReceiver
    {
        public void CreateFile(string filename)
        {
            Console.WriteLine($"Creating file: {filename}");
        }

        public void WriteFile(string filename, string content)
        {
            Console.WriteLine($"Writing to file: {filename}");
            Console.WriteLine($"Content: {content}");
        }

        public void DeleteFile(string filename)
        {
            Console.WriteLine($"Deleting file: {filename}");
        }
    }
}
