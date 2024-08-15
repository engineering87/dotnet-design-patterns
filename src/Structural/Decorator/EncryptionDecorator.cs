// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Decorator
{
    // Concrete Decorator for Encryption
    public class EncryptionDecorator : NotificationDecorator
    {
        public EncryptionDecorator(Notification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            string encryptedMessage = Encrypt(message);
            _notification.Send(encryptedMessage);
        }

        private string Encrypt(string message)
        {
            return $"[Encrypted]{message}";
        }
    }
}
