# Factory Design Pattern

The Factory Design Pattern is a creational design pattern that provides an interface for creating objects in a super class but allows subclasses to alter the type of objects that will be created. Essentially, the Factory Pattern defines an interface or abstract class for creating an object, but it lets the subclasses decide which class to instantiate. This pattern promotes loose coupling by eliminating the need to bind application-specific classes into the code.

## Key Concepts of the Factory Pattern

1. Factory Method:
The Factory Method defines an interface for creating objects but allows subclasses to alter the type of objects that will be created. It encapsulates the object creation logic in a method, which can be overridden in subclasses.
Typically implemented as a method in a factory class or interface that returns instances of a product interface or abstract class.

2. Product Interface:
Defines the common interface for all products that the factory method will produce. This allows the client code to interact with different types of products through a uniform interface.
Can be an interface or an abstract class that specifies the methods that concrete products must implement.

3. Concrete Products:
These are the specific implementations of the product interface. Each concrete product class implements or inherits from the product interface, providing its own version of the functionality.
Classes that implement the product interface, defining the specific behaviors and attributes of the product.

4. Factory Class:
Contains the factory method that creates and returns instances of concrete products. It may also contain logic to decide which concrete product to instantiate based on input parameters or other criteria.
A class that implements the factory method, often with methods for creating different types of products based on the input or configuration.

## Code Explanation

* **Interface IOperatingSystem**:
This interface defines the common behavior for different operating systems. It includes methods `Configure()` and `DisplayInfo()` that each concrete operating system class must implement.

* **Concrete Classes LinuxOS, WindowsOS**:
These classes implement the `IOperatingSystem` interface and provide specific implementations for the `Configure()` and `DisplayInfo()` methods. Each class represents a different operating system with its unique configuration logic.

* **Factory Class OperatingSystemFactory**:
The `OperatingSystemFactory` is a static class that provides a method `CreateOperatingSystem` to create instances of `IOperatingSystem` based on the provided operating system type (osType). The factory method uses a switch statement to return the correct instance based on the input string.
If an invalid osType is provided, the factory throws an ArgumentException to handle the error.

## Usage

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Creating Linux OS configuration using the factory
        IOperatingSystem linux = OperatingSystemFactory.CreateOperatingSystem("linux");
        linux.Configure();
        linux.DisplayInfo();

        // Creating Windows OS configuration using the factory
        IOperatingSystem windows = OperatingSystemFactory.CreateOperatingSystem("windows");
        windows.Configure();
        windows.DisplayInfo();
    }
}
```