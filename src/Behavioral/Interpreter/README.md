# Interpreter Design Pattern
The Interpreter design pattern is a behavioral pattern that provides a way to evaluate sentences in a language. It is often used to interpret expressions or commands, where you define a grammar and create an interpreter that can parse and execute these expressions.

## Key Concepts of the Interpreter Pattern
1. Abstract Expression:
Definition: An interface or abstract class that defines an Interpret method for interpreting expressions or commands.
Purpose: Provides a common interface for all concrete expressions, allowing them to be used interchangeably.

2. Terminal Expression:
Definition: Concrete implementations of the Abstract Expression that interpret specific elements of the language or commands. These expressions typically implement the actual interpretation logic.
Purpose: Represents the fundamental elements or tokens of the language, such as literals or operators.

3. Non-terminal Expression:
Definition: Concrete classes that represent composite expressions or constructs. These expressions combine or build on terminal expressions to form more complex expressions.
Purpose: Allows for the composition of multiple expressions to create complex queries or commands.

4. Context:
Definition: The object or data structure that contains the information needed for the expressions to interpret. It represents the environment or data being interpreted.
Purpose: Provides the data or state on which the expressions operate.

5. Interpreter:
Definition: The process or mechanism that uses the expressions to interpret or evaluate commands. This often involves parsing input, applying the expressions, and returning results.
Purpose: Executes the interpretation logic defined by the expressions to achieve the desired outcome.

6. Grammar Definition:
Definition: The set of rules or structure for the language or command syntax being interpreted. It defines how expressions are formed and combined.
Purpose: Provides a structured way to represent and process commands or expressions.

7. Flexibility and Extensibility:
Definition: The pattern allows for the addition of new expressions or commands without altering existing code.
Purpose: Supports the Open/Closed Principle by enabling extensions through new expressions rather than modifying existing ones.

8. Separation of Concerns:
Definition: The pattern separates the logic for interpreting commands from the data being interpreted.
Purpose: Enhances modularity and maintainability by keeping the interpretation logic distinct from the data structure or context.

## Code Explanation
* **Abstract Expression**:
`IExpression` interface that declares a method `Interpret(File file)` for interpreting a file based on some criteria.
Provides a common interface for all concrete expressions.

* **Terminal Expressions**:
`FilenameFilter`: A terminal expression that checks if a file name contains a specific substring.
    - Constructor: Takes the filename substring to search for.
    - Interpret Method: Checks if the file name contains the substring.

* **ExtensionFilter**: 
`ExtensionFilter`: A terminal expression that checks if a file has a specific extension.
    - Constructor: Takes the file extension to search for.
    - Interpret Method: Checks if the file extension matches the given extension.

* **Context**:
`File` represents a file with a name and extension.
The object that is interpreted by the expressions. It holds the data that the expressions operate on.

## Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create a list of files
        var files = new List<File>
        {
            new File("document1.txt", "txt"),
            new File("presentation.pptx", "pptx"),
            new File("notes.docx", "docx"),
            new File("image.png", "png")
        };

        // Define expressions to filter files
        IExpression filenameFilter = new FilenameFilter("doc");
        IExpression extensionFilter = new ExtensionFilter("png");

        // Apply filters to the list of files
        Console.WriteLine("Files containing 'doc' in their name:");
        foreach (var file in files.Where(f => filenameFilter.Interpret(f)))
        {
            Console.WriteLine($"- {file.Name}");
        }

        Console.WriteLine("\nFiles with '.png' extension:");
        foreach (var file in files.Where(f => extensionFilter.Interpret(f)))
        {
            Console.WriteLine($"- {file.Name}");
        }
    }
}
```