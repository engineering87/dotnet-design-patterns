# Template Method Design Pattern
The Template Method design pattern defines the skeleton of an algorithm in a base class, allowing subclasses to override specific steps of the algorithm without changing its structure. It's a behavioral pattern often used to encapsulate the invariant parts of an algorithm, while allowing the variable parts to be redefined by subclasses.

## Key Concepts of the Template Method
1. Template Method:
The Template Method is a method in an abstract class that defines the overall structure of an algorithm. It consists of a series of method calls, some of which may be abstract or have default implementations. This method controls the algorithm's sequence of execution.

2. Abstract Methods:
Within the Template Method, certain steps are defined as abstract methods. These methods are declared in the abstract class but lack an implementation. Subclasses are required to provide their own implementations for these methods. The purpose is to allow subclasses to define the specific behavior of these steps while preserving the overall algorithm structure.

3. Concrete Methods:
The abstract class may also define concrete methods, which provide default implementations for certain steps of the algorithm. These methods can be used as-is by subclasses or can be overridden to provide different behavior. This allows flexibility and reuse of common code.

4. Hooks:
A hook is a method in the abstract class that does nothing or provides a default implementation, and subclasses can optionally override it. Hooks provide a way to extend or customize parts of the algorithm without being forced to override every method.

5. Invariance vs. Variance:
The Template Method pattern separates the invariant parts of an algorithm (those that remain constant) from the variant parts (those that may change). The invariant parts are implemented in the abstract class, while the variant parts are left to subclasses to implement.

6. Subclassing:
Subclasses inherit the Template Method and can customize the behavior of the algorithm by overriding the abstract methods and hooks. This allows for different implementations of the algorithm's steps while maintaining the overall structure.

7. Encapsulation of Algorithm:
The pattern encapsulates the algorithm's structure within the abstract class. The subclasses are not concerned with the overall flow but only with implementing or modifying specific steps. This encapsulation makes the code more organized and easier to maintain.

8. Non-Overridable Template Method:
The Template Method itself is often marked as final or sealed (depending on the programming language) to prevent subclasses from overriding it. This ensures that the algorithm's structure remains consistent and intact.

9. Reusability and Maintainability:
By defining the core algorithm in the abstract class, the Template Method pattern promotes code reuse and reduces duplication. When the algorithm changes, modifications are made in the abstract class, which automatically applies to all subclasses. This enhances maintainability.

## Code Explanation
* **Abstract Class FileProcessor**:
This class defines the `ProcessFile` method, which is the Template Method. It outlines the steps of the algorithm: opening the file, reading its content, processing the content, and closing the file.
Some steps, such as `OpenFile` and `CloseFile`, are implemented with a default behavior but can be overridden if needed.
Other steps, `ReadFileContent` and `ProcessContent`, are abstract and must be implemented by subclasses because they depend on the specific file type.

* **Concrete Class TextFileProcessor**:
Implements file processing for text files.
Overrides `OpenFile`, `ReadFileContent`, `ProcessContent`, and `CloseFile` to handle the specifics of text files.

* **Concrete Class CsvFileProcessor**:
Implements file processing for CSV files.
Similar to `TextFileProcessor`, but the `ProcessContent` method is designed to handle CSV data, splitting lines by newline characters and columns by commas.

## Usage
```csharp
class Program
    {
        static void Main(string[] args)
        {
            // Example usage
            FileProcessor textProcessor = new TextFileProcessor();
            textProcessor.ProcessFile("example.txt");

            Console.WriteLine();

            FileProcessor csvProcessor = new CsvFileProcessor();
            csvProcessor.ProcessFile("example.csv");
        }
    }
```