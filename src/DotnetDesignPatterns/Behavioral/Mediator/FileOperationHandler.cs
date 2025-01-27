// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    // Colleague: File Operation Handler
    public class FileOperationHandler
    {
        private IFileManager _mediator;

        public void SetMediator(IFileManager mediator)
        {
            _mediator = mediator;
        }

        public void CreateFile(string filename)
        {
            Console.WriteLine($"Creating file: {filename}");
        }

        public void OpenFile(string filename)
        {
            Console.WriteLine($"Opening file: {filename}");
        }

        public void DeleteFile(string filename)
        {
            Console.WriteLine($"Deleting file: {filename}");
        }
    }
}
