// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    /// <summary>
    /// A request captured as an object, so it can be stored and reversed.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Performs the request.
        /// </summary>
        void Execute();

        /// <summary>
        /// Reverses what Execute did.
        /// </summary>
        void Undo();
    }
}
