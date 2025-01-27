// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Facade
{
    // Subsystem 1: File Reader
    public class FileReader
    {
        public string ReadFile(string filePath)
        {
            // Simulate reading a file
            Console.WriteLine($"Reading file from {filePath}");
            return "File content";
        }
    }
}
