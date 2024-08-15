// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Bridge
{
    public interface IFileSystem
    {
        void WriteToFile(string fileName, string content);
        string ReadFromFile(string fileName);
    }
}
