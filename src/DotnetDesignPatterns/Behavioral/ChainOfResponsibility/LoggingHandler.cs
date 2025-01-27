// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.ChainOfResponsibility
{
    // Concrete Handler: Logging
    public class LoggingHandler : FileOperationHandler
    {
        public override void HandleRequest(string operationType, string fileName)
        {
            Console.WriteLine($"[LOG] Operation '{operationType}' on file '{fileName}'");

            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(operationType, fileName);
            }
        }
    }
}
