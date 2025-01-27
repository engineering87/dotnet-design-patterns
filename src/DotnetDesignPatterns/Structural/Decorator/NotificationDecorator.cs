// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    // Decorator
    public abstract class NotificationDecorator : Notification
    {
        protected Notification _notification;

        protected NotificationDecorator(Notification notification)
        {
            _notification = notification;
        }
    }
}
