// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.State
{
    // Concrete State: Opened
    public class OpenedState : IFileState
    {
        public void Open(FileContext context)
        {
            Console.WriteLine("File is already opened.");
        }

        public void Close(FileContext context)
        {
            Console.WriteLine("File closed.");
            context.State = new ClosedState();
        }

        public void Edit(FileContext context)
        {
            Console.WriteLine("File is being edited.");
        }
    }
}
