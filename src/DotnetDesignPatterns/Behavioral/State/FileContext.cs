// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.State
{
    /// <summary>
    /// The context. It holds the current state and delegates every call to it.
    /// </summary>
    public class FileContext
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// The state the context is currently in.
        /// </summary>
        public IFileState State { get; set; }

        /// <summary>
        /// Starts the context in the created state.
        /// </summary>
        public FileContext()
        {
            State = new CreatedState();
        }

        /// <summary>
        /// Delegates the open request to the current state.
        /// </summary>
        public void Open()
        {
            State.Open(this);
        }

        /// <summary>
        /// Delegates the close request to the current state.
        /// </summary>
        public void Close()
        {
            State.Close(this);
        }

        /// <summary>
        /// Delegates the edit request to the current state.
        /// </summary>
        public void Edit()
        {
            State.Edit(this);
        }
    }
}
