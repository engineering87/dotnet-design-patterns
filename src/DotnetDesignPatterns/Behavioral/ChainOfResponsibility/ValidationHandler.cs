// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.ChainOfResponsibility
{
    // Concrete Handler: Validation
    /// <summary>
    /// Checks that the request is well formed.
    /// </summary>
    public class ValidationHandler : FileOperationHandler
    {
        /// <summary>
        /// Rejects an invalid request, otherwise passes it on.
        /// </summary>
        /// <param name="operationType">The operation being requested, for example read or write.</param>
        /// <param name="fileName">The name of the file.</param>
        public override void HandleRequest(string operationType, string fileName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(operationType);
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

            Output.WriteLine($"[VALIDATION] Validating operation '{operationType}' on file '{fileName}'");

            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(operationType, fileName);
            }
        }
    }
}
