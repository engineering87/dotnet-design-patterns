// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    /// <summary>
    /// The base of every decorator. It holds the wrapped notification and passes the call along.
    /// </summary>
    public abstract class NotificationDecorator : Notification
    {
        /// <summary>
        /// The notification this decorator wraps.
        /// </summary>
        protected readonly Notification _notification;

        /// <summary>
        /// Wraps another notification.
        /// </summary>
        /// <param name="notification">The notification this decorator wraps.</param>
        protected NotificationDecorator(Notification notification)
        {
            ArgumentNullException.ThrowIfNull(notification);

            _notification = notification;
        }
    }
}
