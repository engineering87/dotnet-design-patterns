// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.State
{
    // Concrete State: Created
    /// <summary>
    /// The state of a file that exists but has not been opened.
    /// </summary>
    public class CreatedState : IFileState
    {
        /// <summary>
        /// Opens the file and moves the context to the opened state.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        public void Open(FileContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Output.WriteLine("File opened.");
            context.State = new OpenedState();
        }

        /// <summary>
        /// Rejects the request, since the file was never opened.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        public void Close(FileContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Output.WriteLine("Cannot close the file. It is not opened.");
        }

        /// <summary>
        /// Rejects the request, since the file is not open.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        public void Edit(FileContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Output.WriteLine("Cannot edit the file. It is not opened.");
        }
    }
}
