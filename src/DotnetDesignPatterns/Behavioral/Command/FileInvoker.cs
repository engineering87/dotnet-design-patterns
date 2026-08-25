// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Command
{
    /// <summary>
    /// Runs commands without knowing what they do or who carries them out. It keeps a
    /// history of what it has run, which is the reason to turn a request into an object
    /// in the first place: the invoker can queue it, repeat it, or take it back.
    /// </summary>
    public class FileInvoker
    {
        private readonly List<ICommand> _history = new();

        /// <summary>
        /// The commands executed and not yet undone, oldest first.
        /// </summary>
        public IReadOnlyList<ICommand> History => _history;

        /// <summary>
        /// Runs a command and records it, so that it can be undone later.
        /// </summary>
        /// <param name="command">The command the invoker will run.</param>
        public void Execute(ICommand command)
        {
            ArgumentNullException.ThrowIfNull(command);

            command.Execute();
            _history.Add(command);
        }

        /// <summary>
        /// Undoes the most recent command and drops it from the history.
        /// </summary>
        /// <returns>True when a command was undone, false when the history was empty.</returns>
        public bool Undo()
        {
            if (_history.Count == 0)
            {
                return false;
            }

            var last = _history[^1];
            _history.RemoveAt(_history.Count - 1);
            last.Undo();
            return true;
        }

        /// <summary>
        /// Undoes every command in the history, most recent first.
        /// </summary>
        public void UndoAll()
        {
            while (Undo())
            {
            }
        }
    }
}
