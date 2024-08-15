// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Facade
{
    // Subsystem 2: File Writer
    public class FileWriter
    {
        public void WriteFile(string filePath, string content)
        {
            // Simulate writing to a file
            Console.WriteLine($"Writing to file at {filePath}");
        }
    }
}
