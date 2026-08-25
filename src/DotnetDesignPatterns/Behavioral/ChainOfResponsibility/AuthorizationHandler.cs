// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.ChainOfResponsibility
{
    // Concrete Handler: Authorization
    /// <summary>
    /// Checks that the operation is allowed before anything else runs.
    /// </summary>
    public class AuthorizationHandler : FileOperationHandler
    {
        /// <summary>
        /// Rejects a forbidden operation, otherwise passes the request on.
        /// </summary>
        /// <param name="operationType">The operation being requested, for example read or write.</param>
        /// <param name="fileName">The name of the file.</param>
        public override void HandleRequest(string operationType, string fileName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(operationType);
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

            Output.WriteLine($"[AUTHORIZATION] Checking permissions for '{operationType}' on file '{fileName}'");

            if (operationType != "delete") // Simulate authorization check
            {
                if (_nextHandler != null)
                {
                    _nextHandler.HandleRequest(operationType, fileName);
                }
            }
            else
            {
                Output.WriteLine($"[AUTHORIZATION] Permission denied for '{operationType}' operation on file '{fileName}'");
            }
        }
    }
}
