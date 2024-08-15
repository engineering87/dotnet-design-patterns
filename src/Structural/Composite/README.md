# Composite Design Pattern

The Composite Design Pattern is a structural pattern that allows you to compose objects into tree structures to represent part-whole hierarchies. This pattern is useful when you want to treat individual objects and compositions of objects uniformly.

## Key Concepts of the Composite Pattern

1. Component:
Defines the common interface or abstract class for all objects in the hierarchy, both leaf and composite. It declares the operations that can be performed on the objects, such as rendering or calculating size.
This base class or interface provides a common contract for both leaf and composite nodes, allowing clients to interact with them in a uniform way.

2. Leaf:
Represents the end objects in the hierarchy that do not have any children. Leaf nodes implement the Component interface and provide concrete behavior for the operations defined by the Component.
These are the objects that do not have any further sub-objects. For example, in a file system hierarchy, individual files would be leaf nodes.

3. Composite:
Represents nodes that can contain other Component objects, either leaves or other composites. Composite nodes implement the Component interface and manage a collection of child components.
This class provides methods to add, remove, and access child components. It aggregates the behavior of its children and delegates operations to them.

## Code Explanation

* **Component**:
`FileSystemComponent` is an abstract class that defines the common interface for both leaf and composite objects. It declares methods for displaying the component and calculating its size.

* **Leaf**:
Class `File` represents the end objects in the hierarchy (files). It implements the Display and CalculateSize methods for files.

* **Composite**:
Class `Directory` represents nodes that can contain other components (directories or files). It manages child components and implements the `Display` and `CalculateSize` methods to aggregate their behavior.

## Usage

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create files
        var file1 = new File("File1.txt", 100);
        var file2 = new File("File2.jpg", 500);

        // Create directories
        var directory1 = new Directory("Directory1");
        var directory2 = new Directory("Directory2");

        // Build hierarchy
        directory1.Add(file1);
        directory1.Add(file2);
        directory2.Add(directory1);

        // Display hierarchy
        directory2.Display(1);

        // Calculate size
        Console.WriteLine($"Total size of {directory2.Name}: {directory2.CalculateSize()} bytes");
    }
}
```