// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Bridge
{
    public class WindowsFileSystem : IFileSystem
    {
        public void WriteToFile(string fileName, string content)
        {
            Console.WriteLine($"Writing to Windows file: {fileName}");
            // Windows-specific file writing logic
        }

        public string ReadFromFile(string fileName)
        {
            Console.WriteLine($"Reading from Windows file: {fileName}");
            // Windows-specific file reading logic
            return "File content from Windows";
        }
    }
}
