# Mediator Design Pattern
The Mediator design pattern is a behavioral pattern that helps reduce the direct dependencies between objects by introducing a mediator that facilitates communication between them. In the context of file operations within an operating system, a mediator could be used to manage interactions between different components, such as a file manager, file operations, and the user interface.

## Key Concepts of the Mediator Pattern
1. Mediator Interface:
The mediator interface defines the contract for communication between the different components (colleagues) that interact with each other.
It usually contains methods that facilitate the communication and coordination between the colleagues.

2. Concrete Mediator:
The concrete mediator implements the mediator interface and coordinates communication among colleagues.
It contains references to all the colleague objects and handles the communication logic, so the colleagues don’t interact with each other directly.
It centralizes the control logic, simplifying the system by reducing the direct dependencies between colleagues.

3. Colleague Objects:
These are the components or objects that communicate with each other through the mediator.
Each colleague is aware of the mediator but does not need to know about the other colleagues directly.
They communicate by calling methods on the mediator, which then forwards the requests to the appropriate colleague.

4. Decoupling:
The primary purpose of the mediator pattern is to reduce the tight coupling between colleague objects by abstracting their communication through a mediator.
Colleagues no longer need to know about each other's existence, which makes the system easier to maintain and extend.

5. Centralized Control:
The mediator pattern centralizes the control of communication between objects into a single mediator class, which can lead to more manageable and understandable interactions in complex systems.
However, it may also lead to the mediator becoming too complex, as it might need to handle many different types of interactions.

6. Flexibility and Extensibility:
Since the communication logic is encapsulated in the mediator, it’s easier to modify or extend the system. You can add new colleagues or modify existing ones without altering the code for other colleagues.
This flexibility makes the mediator pattern suitable for systems where the interaction between components might change over time.

6. Reduced Direct Dependencies:
By reducing the direct dependencies between colleague objects, the mediator pattern helps in creating more modular and testable code.
Each colleague object can be developed, tested, and maintained independently, with the mediator coordinating their interactions.

## Code Explanation
* **Mediator Interface**:
`IFileManager` interface defines the methods for interacting with different components: creating, opening, deleting files, and notifying about events.

* **Concrete Mediator**:
`FileManager` coordinates the communication between the `FileExplorer`, `FileOperationHandler`, and `Logger`. It ensures that these components do not need to reference each other directly.
It has methods like `CreateFile`, `OpenFile`, and `DeleteFile`, which delegate the work to the FileOperationHandler.

* **Colleagues**:
`FileExplorer`: Represents the user interface or the component that interacts with the user. It selects files and invokes operations like creating, opening, or deleting them.
`FileOperationHandler`: Performs the actual file operations such as creating, opening, and deleting files.
`Logger`: Logs actions performed in the system, like file creation or deletion.

## Usage

```csharp
class Program
    {
        static void Main(string[] args)
        {
            // Create Colleagues
            var fileExplorer = new FileExplorer();
            var fileOperationHandler = new FileOperationHandler();
            var logger = new Logger();

            // Create Mediator
            var fileManager = new FileManager(fileExplorer, fileOperationHandler, logger);

            // Client interacts with FileExplorer
            fileExplorer.SelectFile("example.txt");
            fileExplorer.CreateFile();  // Output: Creating file: example.txt
                                        // Output: [LOG]: File created: example.txt

            fileExplorer.OpenFile();    // Output: Opening file: example.txt
                                        // Output: [LOG]: File opened: example.txt

            fileExplorer.DeleteFile();  // Output: Deleting file: example.txt
                                        // Output: [LOG]: File deleted: example.txt
        }
    }
```