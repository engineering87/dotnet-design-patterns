// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Observer
{
    // Concrete Observer 2: Email Notifier
    public class EmailNotifier : IFileObserver
    {
        public void Update(string fileName, string changeType)
        {
            Console.WriteLine($"[Email Notifier] Sending email: File {fileName} has been {changeType}.");
        }
    }
}
