// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Memento
{
    // Caretaker: Manages mementos
    public class FileHistory
    {
        private readonly Stack<FileMemento> _undoStack = new Stack<FileMemento>();
        private readonly Stack<FileMemento> _redoStack = new Stack<FileMemento>();
        private readonly FileEditor _fileEditor;

        public FileHistory(FileEditor fileEditor)
        {
            _fileEditor = fileEditor;
        }

        public void Save()
        {
            _undoStack.Push(_fileEditor.Save());
            _redoStack.Clear(); // Clear redo history after a new save
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push(_fileEditor.Save()); // Save the current state for redo
                _fileEditor.Restore(_undoStack.Pop());
            }
            else
            {
                Console.WriteLine("No states to undo.");
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(_fileEditor.Save()); // Save the current state for undo
                _fileEditor.Restore(_redoStack.Pop());
            }
            else
            {
                Console.WriteLine("No states to redo.");
            }
        }
    }
}
