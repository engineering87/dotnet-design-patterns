# Command Design Pattern
The Command design pattern is a behavioral design pattern in which an object is used to encapsulate all the information needed to perform an action or trigger an event at a later time. This pattern allows for the separation of concerns, making it easier to handle, queue, and log operations.

## Key Concepts of the Command Pattern
1. Command Interface:
The command interface declares a method for executing the command. Typically, this is named `Execute()` or similar.
This interface might also include an `Undo()` method to allow reversing the operation if needed.

2. Concrete Command:
A concrete command class implements the command interface and defines the binding between an action and a receiver.
It holds a reference to the receiver object, which performs the action when the command’s `Execute()` method is called.
This class can also implement an `Undo()` method to reverse the operation.

3. Receiver:
The receiver is the object that performs the actual work when the command is executed.
It contains the business logic necessary to carry out the request.
The receiver doesn’t know anything about the command interface, only how to perform the requested action.

4. Invoker:
The invoker is responsible for initiating requests or commands. It holds a reference to the command object and triggers its `Execute()` method.
The invoker doesn’t know the details of how the request will be handled, only that it will be executed when needed.

5. Client:
The client is responsible for creating command objects and configuring them with the appropriate receiver.
The client decides which command to execute and passes it to the invoker.

6. Decoupling of Sender and Receiver:
The Command pattern decouples the object that invokes the operation (invoker) from the one that knows how to perform it (receiver).
This allows for greater flexibility, as commands can be passed around, queued, or stored without needing to know anything about the implementation details.

7. Support for Undo/Redo:
By encapsulating operations in objects, the Command pattern naturally supports undo/redo functionality.
Each command can store state information that allows it to reverse the operation if needed, which is useful in scenarios like text editors or transaction systems.

8. Command History and Queuing:
Commands can be stored in a history list or queue, allowing for deferred execution, batch processing, or replaying a sequence of commands.
This is particularly useful in scenarios where you need to maintain a log of operations or execute commands later.

9. Extensibility:
The Command pattern makes it easy to add new commands without altering existing classes.
New commands can be created by simply implementing the command interface and defining the `Execute()` method, without needing to modify the invoker or receiver.

10. Macro Commands:
The Command pattern supports macro commands, which are commands that execute a sequence of other commands.
This allows grouping multiple operations into a single command, which can then be executed or undone as a single unit.

## Code Explanation
* **Command Interface**:
`ICommand` interface defines the Execute and Undo methods, which concrete command classes will implement.

* **Receiver**:
`FileSystemReceiver` class simulates the file system in an operating system. It provides methods like `CreateFile`, `WriteFile`, and `DeleteFile` to perform actual operations.

* **Concrete Command Classes**:
- CreateFileCommand: Encapsulates the action of creating a file.
- WriteFileCommand: Encapsulates the action of writing content to a file.
- DeleteFileCommand: Encapsulates the action of deleting a file.

Each of these classes contains a reference to the `FileSystemReceiver` and uses it to perform the specific operation when Execute is called. They also implement Undo to reverse the operation.

* **Invoker**:
`FileInvoker` class is responsible for executing the command. It holds a reference to a `ICommand` object and calls its Execute and Undo methods.

## Usage
```csharp
class Program
    {
        static void Main(string[] args)
        {
            // Receiver
            var fileSystem = new FileSystemReceiver();

            // Commands
            var createCommand = new CreateFileCommand(fileSystem, "example.txt");
            var writeCommand = new WriteFileCommand(fileSystem, "example.txt", "Hello, World!");
            var deleteCommand = new DeleteFileCommand(fileSystem, "example.txt");

            // Invoker
            var fileInvoker = new FileInvoker(createCommand);
            fileInvoker.Execute();  // Output: Creating file: example.txt
            fileInvoker.Undo();     // Output: Deleting file: example.txt

            fileInvoker = new FileInvoker(writeCommand);
            fileInvoker.Execute();  // Output: Writing to file: example.txt
                                    // Content: Hello, World!
            fileInvoker.Undo();     // Output: Undoing write to file: example.txt

            fileInvoker = new FileInvoker(deleteCommand);
            fileInvoker.Execute();  // Output: Deleting file: example.txt
            fileInvoker.Undo();     // Output: Undoing delete: Recreating file example.txt
        }
    }
```