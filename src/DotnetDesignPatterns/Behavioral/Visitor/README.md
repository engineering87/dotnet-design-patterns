# Visitor Design Pattern
The Visitor design pattern is a behavioral pattern that allows you to add further operations to objects without modifying their classes. It separates the algorithm from the object structure it operates on, making it easy to add new operations without altering the object structures.

## Key Concepts of the Visitor Pattern
1. Visitor Interface:
Definition: The Visitor interface declares a set of visiting methods, one for each type of element in the object structure.
Purpose: Allows the implementation of operations that can be applied to elements of different types in the object structure. Each method in the interface corresponds to a particular type of element.
Example: In a file system, `IFileSystemVisitor` might define methods like `Visit(File file)` and `Visit(Directory directory)`.

2. Concrete Visitor:
Definition: A class that implements the Visitor interface and provides concrete implementations of the visiting methods.
Purpose: Encapsulates the behavior or operation that you want to apply to elements of the object structure. Each visitor class represents a different operation.
Example: `SizeCalculationVisitor` and `FileListingVisitor` can be concrete visitors that implement operations like calculating the total size of files or listing files in a directory.

3. Element Interface:
Definition: An interface or abstract class that defines an Accept method. This method takes a visitor as an argument.
Purpose: Allows the element to "accept" a visitor, which means that the element will delegate the operation to the visitor.
Example: `IFileSystemElement` with an `Accept(IFileSystemVisitor visitor)` method.

4. Concrete Elements:
Definition: Classes that implement the `Element` interface and represent the objects in the structure on which operations will be performed.
Purpose: These are the objects that can be visited by visitors. They implement the Accept method to delegate the operation to the appropriate visitor method.
Example: `File` and `Directory` are concrete elements in a file system.

5. Double Dispatch:
Definition: A key feature of the Visitor pattern that allows a method call to be dispatched to different methods based on both the type of the visitor and the type of the element being visited.
Purpose: Enables the correct operation to be applied depending on both the element and the visitor, without needing to use if or switch statements.
Example: When a `File` object calls `visitor.Visit(this)`, the call is dispatched to the `Visit(File file)` method on the visitor, ensuring the correct operation is performed.

6. Separation of Algorithms and Object Structure:
Definition: The Visitor pattern separates the algorithms from the object structure on which they operate, making the object structure easier to maintain and extend.
Purpose: Enhances modularity by allowing new operations to be added without modifying the objects themselves.
Example: You can add new operations to the file system by creating new visitors without changing the `File` or `Directory` classes.

7. Extensibility:
Definition: New operations can be added easily by creating new visitor classes, without altering the existing element classes.
Purpose: Supports the Open/Closed Principle, allowing the system to be extended with new behaviors without modifying the existing code.
Example: Adding a `FileSearchVisitor` to search for files by name or extension in the file system.

8. Element Structure Complexity:
Definition: The Visitor pattern is well-suited for complex object structures, particularly when the structure is relatively stable and the operations on the structure may change or need to be extended.
Purpose: Simplifies the addition of operations in complex structures by avoiding the need to modify element classes whenever a new operation is required.

9. Visitor Encapsulation:
Definition: Visitors encapsulate the logic that operates on the elements, which keeps the element classes lightweight and focused on their core responsibilities.
Purpose: Reduces the burden on element classes and promotes a cleaner, more maintainable design.
Example: The `File` and `Directory` classes do not need to know how to calculate sizes or list files; these behaviors are handled by the visitors.

## Code Explanation
* **Visitor Interface**:
Interface `IFileSystemVisitor` defines the operations that can be performed on different elements of the file system.
Methods `Visit(File file)` and `Visit(Directory directory)` are implemented by concrete visitors to perform operations specific to files and directories.

* **Concrete Visitors**:
`SizeCalculationVisitor`: Calculates the total size of all files in the file system.
`FileListingVisitor`: Lists all files and directories in the file system.

* **Element Interface**:
Interface `IFileSystemElement` defines an Accept method that takes a visitor as an argument.
This method allows an element (file or directory) to accept a visitor and lets the visitor perform its operation on the element.

* **Concrete Elements**:
`File`: Represents a file in the file system, storing its name and size. Implements the Accept method to allow visitors to operate on it.
`Directory`: Represents a directory, which can contain multiple files and subdirectories. It also implements the Accept method and iterates through its elements to apply the visitor operation.

## Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create file system structure
        var file1 = new File("file1.txt", 1200);
        var file2 = new File("file2.txt", 2500);
        var subdir = new Directory("subdir");
        subdir.AddElement(file2);

        var rootDir = new Directory("root");
        rootDir.AddElement(file1);
        rootDir.AddElement(subdir);

        // Calculate total size using Visitor
        var sizeVisitor = new SizeCalculationVisitor();
        rootDir.Accept(sizeVisitor);
        Console.WriteLine($"Total size: {sizeVisitor.TotalSize} bytes");

        // List all files and directories using Visitor
        var listingVisitor = new FileListingVisitor();
        rootDir.Accept(listingVisitor);
    }
}
```