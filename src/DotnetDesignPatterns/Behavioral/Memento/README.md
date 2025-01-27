# Memento Design Pattern
The Memento design pattern is a behavioral pattern that allows capturing and externalizing an object's internal state without violating its encapsulation. The object can be restored to this state later. This pattern is particularly useful in scenarios where you need to implement undo/redo functionality.

## Key Concepts of the Memento Pattern
1. Memento:
Definition: The Memento is an object that stores the internal state of another object (the Originator) without exposing its internal structure.
Purpose: It acts as a snapshot of the state of the Originator at a specific point in time, allowing the state to be restored later.
Immutability: Typically, the Memento is immutable to ensure that the state cannot be altered after it has been saved.

2. Originator:
Definition: The Originator is the object whose state needs to be saved and restored.
Responsibilities: It is responsible for creating a Memento that captures its current state and for restoring its state from a Memento.
State Management: The Originator manages its internal state and provides methods for saving and restoring it.

2. Caretaker:
Definition: The Caretaker is responsible for managing and storing Mementos.
Responsibilities: It keeps track of multiple Mementos, often using a stack or other data structure, to facilitate undo/redo functionality.
Limitation: The Caretaker does not modify or directly interact with the contents of the Memento; it only stores and retrieves them.

3. Encapsulation:
State Preservation: The Memento pattern allows the internal state of the Originator to be preserved without exposing its internal details.
Decoupling: It decouples the internal state management of the Originator from the operations that modify or restore the state.

4. Undo/Redo Functionality:
State History: The pattern enables tracking of state changes over time, making it possible to revert to previous states or reapply undone states.
Command History: Often used in conjunction with a history or command stack to manage multiple state changes and transitions.

5. Snapshot Management:
State Capture: The Memento pattern captures the state of the Originator at a specific moment, allowing for precise control over state transitions.
State Restoration: The pattern supports restoring the state to any previously saved snapshot, facilitating state recovery or rollback.

6. Complex State Handling:
Complex Objects: The pattern is useful for managing complex objects with intricate states that need to be saved and restored independently of their internal structure.
State Integrity: It ensures that the integrity of the state is maintained and not exposed to other parts of the system.

## Code Explanation
* **Memento**:
`FileMemento` class stores the internal state of the `FileEditor`. In this case, it stores the content of the file.
The memento is immutable once created, ensuring that the saved state cannot be altered after creation.

* **Originator**:
`FileEditor` is the object whose state we want to save and restore. It contains a method Write to change the content of the file.
It has a `Save` method that creates a new `FileMemento` containing the current state and a `Restore` method that restores the state from a memento.

* **Caretaker**:
`FileHistory` class manages the mementos. It keeps a stack of mementos for undo and redo operations.
`Save` method saves the current state of the file by pushing a new memento onto the undo stack.
`Undo` method pops the latest memento from the undo stack and uses it to restore the file's state. It also pushes the current state onto the redo stack.
`Redo` method restores the state from the redo stack if an undo has been performed.

## Usage
```csharp
class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the FileEditor
            var fileEditor = new FileEditor();

            // Create an instance of FileHistory (the Caretaker)
            var fileHistory = new FileHistory(fileEditor);

            // Perform some operations
            fileEditor.Write("Version 1");
            fileHistory.Save();

            fileEditor.Write("Version 2");
            fileHistory.Save();

            fileEditor.Write("Version 3");
            fileHistory.Save();

            // Undo operations
            fileHistory.Undo();  // Output: Restored file content to: Version 2
            fileHistory.Undo();  // Output: Restored file content to: Version 1

            // Redo operation
            fileHistory.Redo();  // Output: Restored file content to: Version 2
        }
    }
```