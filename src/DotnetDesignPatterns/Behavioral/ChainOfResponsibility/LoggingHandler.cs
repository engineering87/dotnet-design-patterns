// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.ChainOfResponsibility
{
    // Concrete Handler: Logging
    /// <summary>
    /// Records the request at the end of the chain.
    /// </summary>
    public class LoggingHandler : FileOperationHandler
    {
        /// <summary>
        /// Logs the request, then passes it on.
        /// </summary>
        /// <param name="operationType">The operation being requested, for example read or write.</param>
        /// <param name="fileName">The name of the file.</param>
        public override void HandleRequest(string operationType, string fileName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(operationType);
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

            Output.WriteLine($"[LOG] Operation '{operationType}' on file '{fileName}'");

            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(operationType, fileName);
            }
        }
    }
}
