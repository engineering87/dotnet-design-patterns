// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.ChainOfResponsibility
{
    // Abstract Handler
    public abstract class FileOperationHandler
    {
        protected FileOperationHandler _nextHandler;

        public void SetNext(FileOperationHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(string operationType, string fileName);
    }
}
