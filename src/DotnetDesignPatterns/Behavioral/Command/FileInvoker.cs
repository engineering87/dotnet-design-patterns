// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    // Invoker Class
    public class FileInvoker
    {
        private readonly ICommand _command;

        public FileInvoker(ICommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            _command.Execute();
        }

        public void Undo()
        {
            _command.Undo();
        }
    }
}
