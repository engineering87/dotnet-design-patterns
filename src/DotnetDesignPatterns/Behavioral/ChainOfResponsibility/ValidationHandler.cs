// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.ChainOfResponsibility
{
    // Concrete Handler: Validation
    public class ValidationHandler : FileOperationHandler
    {
        public override void HandleRequest(string operationType, string fileName)
        {
            Console.WriteLine($"[VALIDATION] Validating operation '{operationType}' on file '{fileName}'");

            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(operationType, fileName);
            }
        }
    }
}
