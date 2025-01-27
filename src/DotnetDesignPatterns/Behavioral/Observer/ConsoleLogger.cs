// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Observer
{
    // Concrete Observer 1: Console Logger
    public class ConsoleLogger : IFileObserver
    {
        public void Update(string fileName, string changeType)
        {
            Console.WriteLine($"[Console Logger] File {fileName} has been {changeType}.");
        }
    }
}
