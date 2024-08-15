# Strategy Design Pattern
The Strategy design pattern is a behavioral pattern that defines a family of algorithms, encapsulates each algorithm, and makes them interchangeable. This pattern allows a client to choose an algorithm from a family of algorithms at runtime. It's particularly useful when you need to select a specific behavior or strategy dynamically.

## Key Concepts of the Strategy Pattern
1. Strategy Interface:
Definition: An interface or abstract class that defines a common method for a family of algorithms or strategies.
Purpose: Provides a way to encapsulate a family of related algorithms or behaviors, allowing them to be interchangeable.

2. Concrete Strategies:
Definition: Classes that implement the Strategy interface, providing specific implementations of the algorithm or behavior.
Purpose: Each concrete strategy implements a different algorithm or variation of the algorithm defined by the Strategy interface.

3. Context:
Definition: The class that uses a Strategy object to perform a particular operation. It maintains a reference to a Strategy object and delegates the algorithm execution to this strategy.
Purpose: Acts as a client of the Strategy interface, providing a way to change the strategy at runtime and execute the algorithm defined by the strategy.

4. Encapsulation of Algorithms:
Definition: Algorithms or behaviors are encapsulated within their own strategy classes, ensuring that each strategy is responsible for its own implementation.
Purpose: Promotes clean code organization by separating different algorithms and keeping them encapsulated within their respective classes.

5. Interchangeability:
Definition: Strategies can be swapped or replaced dynamically at runtime, allowing the context to use different algorithms as needed.
Purpose: Provides flexibility and adaptability, allowing the behavior of an object to be changed without modifying its code.

6. Decoupling:
Definition: The context class is decoupled from the specific implementations of the strategies. It interacts with the Strategy interface rather than concrete strategy classes.
Purpose: Reduces dependencies between the context and specific algorithms, making the system more modular and easier to maintain.

7. Dynamic Behavior Change:
Definition: The ability to change the behavior of the context at runtime by switching the strategy object.
Purpose: Allows the behavior of the system to be modified dynamically based on the current needs or conditions.

8. Open/Closed Principle:
Definition: The Strategy pattern adheres to the Open/Closed Principle, which states that a class should be open for extension but closed for modification.
Purpose: New strategies can be added without modifying the context class or existing strategy classes, promoting extensibility and reducing the risk of introducing bugs.

## Code Explanation
1. Strategy Interface:
`ICompressionStrategy` defines the common interface for all compression strategies. In this case, it has a Compress method that takes a file path as a parameter.

2. Concrete Strategies:
`ZipCompressionStrategy`: Implements the `ICompressionStrategy` interface to compress files using ZIP format. It uses GZipStream for compression but in a ZIP format.
`GZipCompressionStrategy`: Implements the `ICompressionStrategy` interface to compress files using GZIP format. It uses GZipStream directly to compress the file.
Each strategy provides its own implementation of the `Compress` method to handle file compression.

3. Context:
`FileCompressor` maintains a reference to an `ICompressionStrategy` object and delegates the compression task to this strategy.
Provides the `SetCompressionStrategy` method to allow changing the compression strategy at runtime.
Uses the `CompressFile` method to perform the compression by invoking the strategy's `Compress` method.

## Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        var fileCompressor = new FileCompressor();

        // Set ZIP Compression Strategy and compress the file
        fileCompressor.SetCompressionStrategy(new ZipCompressionStrategy());
        fileCompressor.CompressFile(@"C:\Temp\example.txt");

        // Set GZIP Compression Strategy and compress the file
        fileCompressor.SetCompressionStrategy(new GZipCompressionStrategy());
        fileCompressor.CompressFile(@"C:\Temp\example.txt");
    }
}
```