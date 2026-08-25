// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    /// <summary>
    /// Marks the message as urgent before the wrapped notification sends it.
    /// </summary>
    public class PrioritizationDecorator : NotificationDecorator
    {
        /// <summary>
        /// Wraps another notification.
        /// </summary>
        /// <param name="notification">The notification this decorator wraps.</param>
        public PrioritizationDecorator(Notification notification) : base(notification)
        {
        }

        /// <summary>
        /// Marks the message, then sends it.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public override void Send(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            string prioritizedMessage = Prioritize(message);
            _notification.Send(prioritizedMessage);
        }

        private string Prioritize(string message)
        {
            return $"[Priority]{message}";
        }
    }
}
