// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    /// <summary>
    /// Adds logging around the wrapped notification.
    /// </summary>
    public class LoggingDecorator : NotificationDecorator
    {
        /// <summary>
        /// Wraps another notification.
        /// </summary>
        /// <param name="notification">The notification this decorator wraps.</param>
        public LoggingDecorator(Notification notification) : base(notification)
        {
        }

        /// <summary>
        /// Logs the message, then sends it.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public override void Send(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            Log(message);
            _notification.Send(message);
        }

        private void Log(string message)
        {
            Output.WriteLine($"Logging notification: {message}");
        }
    }
}
