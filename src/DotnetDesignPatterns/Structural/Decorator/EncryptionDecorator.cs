// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    /// <summary>
    /// Encrypts the message before the wrapped notification sends it.
    /// </summary>
    public class EncryptionDecorator : NotificationDecorator
    {
        /// <summary>
        /// Wraps another notification.
        /// </summary>
        /// <param name="notification">The notification this decorator wraps.</param>
        public EncryptionDecorator(Notification notification) : base(notification)
        {
        }

        /// <summary>
        /// Encrypts the message, then sends it.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public override void Send(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            string encryptedMessage = Encrypt(message);
            _notification.Send(encryptedMessage);
        }

        private string Encrypt(string message)
        {
            return $"[Encrypted]{message}";
        }
    }
}
