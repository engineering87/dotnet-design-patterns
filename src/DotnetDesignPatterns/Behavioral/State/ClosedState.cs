// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.State
{
    // Concrete State: Closed
    /// <summary>
    /// The state of a file that has been closed.
    /// </summary>
    public class ClosedState : IFileState
    {
        /// <summary>
        /// Reopens the file and moves the context to the opened state.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        public void Open(FileContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Output.WriteLine("File opened.");
            context.State = new OpenedState();
        }

        /// <summary>
        /// Rejects the request, since the file is already closed.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        public void Close(FileContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Output.WriteLine("File is already closed.");
        }

        /// <summary>
        /// Rejects the request, since the file is closed.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        public void Edit(FileContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Output.WriteLine("Cannot edit the file. It is closed.");
        }
    }
}
