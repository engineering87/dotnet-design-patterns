# Adapter Design Pattern

The Adapter Design Pattern is a structural pattern that allows objects with incompatible interfaces to work together. It acts as a bridge between two incompatible interfaces, enabling them to communicate. This pattern is especially useful when integrating new components with existing systems where the interfaces do not match.

## Key Concepts of the Adapter Pattern

1. Adapter:
The adapter is the core component that implements the target interface and holds an instance of the adaptee. It translates the requests from the target interface to the methods of the adaptee.
It implements or inherits from the target interface and translates method calls to the adaptee’s methods. The adapter often uses composition to hold a reference to the adaptee object.

2. Target Interface:
Defines the interface that the client code expects to use. The target interface specifies the methods and properties that the client interacts with.
This is a common interface that the client code uses, and the adapter will implement this interface to provide a unified way to interact with different adaptees.

3. Adaptee:
Represents the existing class or component with an incompatible interface that needs to be adapted. The adaptee provides functionality that the client code needs but does not conform to the target interface.
This is the class with the methods or properties that the adapter will translate into the target interface format.

## Code Explanation

* **Target Interface**:
Interface `ISystemInfo` defines the common interface (`GetSystemDetails()`) that the client code expects to interact with.

* **Adaptee Classes**:
Classes `WindowsOS` and `LinuxOS` represent existing system components with methods that do not match the `ISystemInfo` interface.

* **Adapter Classes**:
Classes `WindowsAdapter` and `LinuxAdapter` implement the `ISystemInfo` interface and adapt the interfaces of the `WindowsOS` and `LinuxOS` classes to this common interface. They translate calls from the target interface to the methods of the adaptee classes.

## Usage

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Instantiate the Adaptees
        WindowsOS windowsOS = new WindowsOS();
        LinuxOS linuxOS = new LinuxOS();

        // Create adapters for the Adaptees
        ISystemInfo windowsAdapter = new WindowsAdapter(windowsOS);
        ISystemInfo linuxAdapter = new LinuxAdapter(linuxOS);

        // Use the adapters through the target interface
        Console.WriteLine($"Windows System Details: {windowsAdapter.GetSystemDetails()}");
        Console.WriteLine($"Linux System Details: {linuxAdapter.GetSystemDetails()}");
    }
}
```