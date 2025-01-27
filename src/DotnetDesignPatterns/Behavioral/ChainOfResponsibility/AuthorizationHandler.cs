// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.ChainOfResponsibility
{
    // Concrete Handler: Authorization
    public class AuthorizationHandler : FileOperationHandler
    {
        public override void HandleRequest(string operationType, string fileName)
        {
            Console.WriteLine($"[AUTHORIZATION] Checking permissions for '{operationType}' on file '{fileName}'");

            if (operationType != "delete") // Simulate authorization check
            {
                if (_nextHandler != null)
                {
                    _nextHandler.HandleRequest(operationType, fileName);
                }
            }
            else
            {
                Console.WriteLine($"[AUTHORIZATION] Permission denied for '{operationType}' operation on file '{fileName}'");
            }
        }
    }
}
