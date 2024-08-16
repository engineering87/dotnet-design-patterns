# Iterator Design Pattern
The Iterator design pattern is a behavioral pattern that provides a way to access the elements of a collection sequentially without exposing the underlying representation of the collection. It allows for traversal of complex data structures, like lists or trees, in a uniform way.

## Key Concepts of the Iterator Pattern
1. Iterator Interface:
Definition: An interface that defines methods for accessing elements of a collection sequentially. Common methods include HasNext() to check if there are more elements, and Next() to retrieve the next element.
Purpose: Provides a standard way to traverse the elements of a collection without needing to understand the internal structure of the collection.

2. Concrete Iterator:
Definition: A class that implements the Iterator interface and maintains the current position within the collection.
Purpose: Implements the traversal logic for the collection, keeping track of the current state and ensuring correct sequential access.

3. Aggregate Interface:
Definition: An interface or abstract class that declares a method for creating an iterator object. This is often named CreateIterator().
Purpose: Provides a way to obtain an iterator for the collection, allowing clients to traverse the collection through the iterator.

4. Concrete Aggregate:
Definition: A class that implements the Aggregate interface and contains the collection of elements. It also provides the implementation of the method to create an iterator.
Purpose: Represents the collection of elements and supports creation of an iterator that can traverse its elements.

5. Element:
Definition: The objects that are contained within the collection and are accessed by the iterator.
Purpose: Represents the items that are iterated over. In the context of the Iterator pattern, these objects are accessed sequentially.

6. Encapsulation of Traversal Logic:
Definition: The Iterator pattern encapsulates the traversal logic inside the iterator object, separating it from the collection.
Purpose: Ensures that the collection can focus on managing its elements, while the iterator handles the traversal details.

7. Uniform Access:
Definition: Provides a consistent way to access elements regardless of the underlying data structure.
Purpose: Allows different types of collections (like lists, trees, or graphs) to be traversed using the same iterator interface, promoting code reuse and consistency.

8. Separation of Concerns:
Definition: Separates the responsibility of iterating over the elements from the collection itself.
Purpose: Makes it easier to modify or extend the collection or iteration logic independently. For example, you can add new types of collections or iterators without changing the existing code.

9. Flexibility and Extensibility:
Definition: Allows for the easy addition of new types of collections or traversal strategies by creating new iterator implementations.
Purpose: Supports the Open/Closed Principle, making the system easier to extend with new functionality without modifying existing code.

## Code Explanation
* **Iterator Interface**:
Definition: `IIterator<T>` defines the methods `HasNext()` and `Next()` for iterating over a collection.
Purpose: Provides a standard way to traverse elements in the collection.

* **Aggregate Interface**:
Definition: `IFileSystemCollection` declares a method `CreateIterator()` that returns an iterator for the collection.
Purpose: Allows the creation of an iterator for traversing the elements.

* **Element Interface**:
Definition: `IFileSystemElement` defines the properties and methods common to all elements in the file system.
Purpose: Ensures that all elements (files and directories) can be treated uniformly.

* **Concrete Elements**:
`File`: Represents a file with a name and implements the `IFileSystemElement` interface.
`Directory`: Represents a directory that can contain files and subdirectories. It implements both `IFileSystemElement` and `IFileSystemCollection` interfaces.
`AddElement` Method: Adds elements (files or subdirectories) to the directory.
`CreateIterator` Method: Returns an iterator for traversing the directory’s elements.

* **Concrete Iterator**:
`FileSystemIterator` implements the `IIterator<IFileSystemElement>` interface and provides methods to traverse the collection.
Purpose: Handles the actual iteration logic for a list of file system elements.

## Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create file system structure
        var file1 = new File("file1.txt");
        var file2 = new File("file2.txt");
        var subdir = new Directory("subdir");
        subdir.AddElement(file2);

        var rootDir = new Directory("root");
        rootDir.AddElement(file1);
        rootDir.AddElement(subdir);

        // Use iterator to traverse the file system
        var iterator = rootDir.CreateIterator();
        while (iterator.HasNext())
        {
            var element = iterator.Next();
            element.PrintDetails();
        }
    }
}
```