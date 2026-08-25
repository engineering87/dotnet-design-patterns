// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    /// <summary>
    /// The undecorated component, which does the actual sending.
    /// </summary>
    public class BasicNotification : Notification
    {
        /// <summary>
        /// Sends the message with no extra behaviour.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public override void Send(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            Output.WriteLine($"Sending notification: {message}");
        }
    }
}
