// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    // Command Interface
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
