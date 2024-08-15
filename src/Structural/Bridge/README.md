# Bridge Design Pattern

The Bridge Design Pattern is a structural pattern that decouples an abstraction from its implementation so that the two can vary independently. This pattern is useful when you need to separate a complex abstraction from its implementation to allow both to evolve independently.

## Key Concepts of the Bridge Pattern

1. Abstraction:
Defines the high-level control logic or interface that the client code interacts with. It provides a way to manage or manipulate complex objects.
The abstraction holds a reference to an implementor object and delegates the actual work to it. This allows the abstraction to remain independent of the specifics of how the tasks are performed.

2. Implementor Interface:
Defines the interface for the implementation classes. This interface specifies the operations that the concrete implementors must provide.
This interface is designed to be independent of the abstraction. It provides the methods or operations that are implemented by concrete classes.

3. Concrete Implementors:
Provide specific implementations of the operations defined in the implementor interface. These classes contain the details of how tasks are performed.
Each concrete implementor provides its own version of the methods declared in the implementor interface, allowing different ways to perform the same operations.

4. Refined Abstraction:
Extends the abstraction to provide more specific behavior or functionality. It uses the implementor to perform tasks but may add additional functionality.
The refined abstraction provides specific implementations of the operations defined in the abstraction and uses the implementor to execute the underlying tasks.

## Code Explanation

* **Abstraction**:
Class `FileManager` provides the high-level file management operations. It holds a reference to the `IFileSystem` implementor, allowing it to delegate file operations.

* **Implementor Interface**:
Interface `IFileSystem` defines the operations that need to be implemented by different file systems. It separates the abstraction from its concrete implementation.

* **Concrete Implementors**:
Classes `LinuxFileSystem` and `WindowsFileSystem` provide specific implementations for file operations on different operating systems. Each concrete implementor handles file operations according to the OS-specific requirements.

* **Refined Abstraction**:
Class `TextFileManager` extends the `FileManager` abstract class and uses the `IFileSystem` interface to perform file operations. This allows for different types of file managers to be created based on the abstraction.

## Usage

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create file system implementations
        IFileSystem windowsFileSystem = new WindowsFileSystem();
        IFileSystem linuxFileSystem = new LinuxFileSystem();

        // Create file managers for text files
        FileManager windowsTextFileManager = new TextFileManager(windowsFileSystem);
        FileManager linuxTextFileManager = new TextFileManager(linuxFileSystem);

        // Use the file managers
        windowsTextFileManager.SaveFile("example.txt", "Hello, Windows!");
        Console.WriteLine(windowsTextFileManager.ReadFile("example.txt"));

        linuxTextFileManager.SaveFile("example.txt", "Hello, Linux!");
        Console.WriteLine(linuxTextFileManager.ReadFile("example.txt"));
    }
}
```