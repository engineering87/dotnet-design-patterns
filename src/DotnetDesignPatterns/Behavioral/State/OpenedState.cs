// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.State
{
    // Concrete State: Opened
    /// <summary>
    /// The state of a file that is open and can be edited.
    /// </summary>
    public class OpenedState : IFileState
    {
        /// <summary>
        /// Rejects the request, since the file is already open.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        public void Open(FileContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Output.WriteLine("File is already opened.");
        }

        /// <summary>
        /// Closes the file and moves the context to the closed state.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        public void Close(FileContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Output.WriteLine("File closed.");
            context.State = new ClosedState();
        }

        /// <summary>
        /// Edits the file.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        public void Edit(FileContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Output.WriteLine("File is being edited.");
        }
    }
}
