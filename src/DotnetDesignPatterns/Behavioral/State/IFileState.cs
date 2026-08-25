// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.State
{
    /// <summary>
    /// One state of the file, holding the behaviour that belongs to it and deciding which state comes next.
    /// </summary>
    public interface IFileState
    {
        /// <summary>
        /// Handles an open request in this state.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        void Open(FileContext context);

        /// <summary>
        /// Handles a close request in this state.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        void Close(FileContext context);

        /// <summary>
        /// Handles an edit request in this state.
        /// </summary>
        /// <param name="context">The context whose state may change.</param>
        void Edit(FileContext context);
    }
}
