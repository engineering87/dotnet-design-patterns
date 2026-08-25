// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Memento
{
    // Caretaker: Manages mementos
    /// <summary>
    /// The caretaker. It keeps snapshots on two stacks, one for undo and one for redo, and never reads inside them.
    /// </summary>
    public class FileHistory
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        private readonly Stack<FileMemento> _undoStack = new Stack<FileMemento>();
        private readonly Stack<FileMemento> _redoStack = new Stack<FileMemento>();
        private readonly FileEditor _fileEditor;

        /// <summary>
        /// Binds the history to the editor it will snapshot.
        /// </summary>
        /// <param name="fileEditor">The editor whose snapshots this caretaker keeps.</param>
        public FileHistory(FileEditor fileEditor)
        {
            ArgumentNullException.ThrowIfNull(fileEditor);

            _fileEditor = fileEditor;
        }

        /// <summary>
        /// Takes a snapshot and clears the redo history.
        /// </summary>
        public void Save()
        {
            _undoStack.Push(_fileEditor.Save());
            _redoStack.Clear(); // Clear redo history after a new save
        }

        /// <summary>
        /// Goes back one step, keeping the current state for redo.
        /// </summary>
        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push(_fileEditor.Save()); // Save the current state for redo
                _fileEditor.Restore(_undoStack.Pop());
            }
            else
            {
                Output.WriteLine("No states to undo.");
            }
        }

        /// <summary>
        /// Goes forward one step, keeping the current state for undo.
        /// </summary>
        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(_fileEditor.Save()); // Save the current state for undo
                _fileEditor.Restore(_redoStack.Pop());
            }
            else
            {
                Output.WriteLine("No states to redo.");
            }
        }
    }
}
