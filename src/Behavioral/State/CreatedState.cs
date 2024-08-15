// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.State
{
    // Concrete State: Created
    public class CreatedState : IFileState
    {
        public void Open(FileContext context)
        {
            Console.WriteLine("File opened.");
            context.State = new OpenedState();
        }

        public void Close(FileContext context)
        {
            Console.WriteLine("Cannot close the file. It is not opened.");
        }

        public void Edit(FileContext context)
        {
            Console.WriteLine("Cannot edit the file. It is not opened.");
        }
    }
}
