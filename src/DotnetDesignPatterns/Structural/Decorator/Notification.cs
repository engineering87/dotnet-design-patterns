// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    /// <summary>
    /// The component that decorators wrap and that clients depend on.
    /// </summary>
    public abstract class Notification
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public abstract void Send(string message);
    }
}
