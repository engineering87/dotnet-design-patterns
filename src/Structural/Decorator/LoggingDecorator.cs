// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    // Concrete Decorator for Logging
    public class LoggingDecorator : NotificationDecorator
    {
        public LoggingDecorator(Notification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            Log(message);
            _notification.Send(message);
        }

        private void Log(string message)
        {
            Console.WriteLine($"Logging notification: {message}");
        }
    }
}
