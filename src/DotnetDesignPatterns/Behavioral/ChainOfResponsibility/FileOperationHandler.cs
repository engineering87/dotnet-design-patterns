// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.ChainOfResponsibility
{
    /// <summary>
    /// One link of the chain. Each handler either deals with the request or passes it to the next one.
    /// </summary>
    public abstract class FileOperationHandler
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// The next handler in the chain, if there is one.
        /// </summary>
        protected FileOperationHandler _nextHandler;

        /// <summary>
        /// Puts a handler after this one.
        /// </summary>
        /// <param name="nextHandler">The handler that receives the request if this one declines it.</param>
        public void SetNext(FileOperationHandler nextHandler)
        {
            ArgumentNullException.ThrowIfNull(nextHandler);

            _nextHandler = nextHandler;
        }

        /// <summary>
        /// Deals with the request, or passes it on.
        /// </summary>
        /// <param name="operationType">The operation being requested, for example read or write.</param>
        /// <param name="fileName">The name of the file.</param>
        public abstract void HandleRequest(string operationType, string fileName);
    }
}
