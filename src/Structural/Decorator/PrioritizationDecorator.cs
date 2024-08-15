// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    // Concrete Decorator for Prioritization
    public class PrioritizationDecorator : NotificationDecorator
    {
        public PrioritizationDecorator(Notification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            string prioritizedMessage = Prioritize(message);
            _notification.Send(prioritizedMessage);
        }

        private string Prioritize(string message)
        {
            return $"[Priority]{message}";
        }
    }
}
