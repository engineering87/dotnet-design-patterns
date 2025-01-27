// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    public class BasicNotification : Notification
    {
        public override void Send(string message)
        {
            Console.WriteLine($"Sending notification: {message}");
        }
    }
}
