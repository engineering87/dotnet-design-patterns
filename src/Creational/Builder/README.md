# Builder Design Pattern

The Builder Design Pattern is a creational design pattern that provides a flexible solution to constructing complex objects. It allows an object to be constructed step-by-step, separating the construction process from the representation. This pattern is particularly useful when an object can be created in multiple ways or when the creation process involves many optional parameters or complex configurations.

## Key Concepts of the Builder Pattern

1. Separation of Construction and Representation:
The Builder Pattern separates the construction of an object from its final representation, allowing the same construction process to create different representations.

2. Step-by-Step Construction:
he object is constructed step-by-step through a series of method calls. This makes the creation process more flexible and easier to manage, especially when dealing with complex objects with many fields or configurations.

3. Immutability:
In many implementations, once the object is built, it is immutable, meaning its state cannot be changed. This ensures that the object is fully configured when it is constructed and remains consistent throughout its lifetime.

## Code Explanation

* **Product Class OperatingSystemConfig**:
The `OperatingSystemConfig` class represents the final product, which is a configuration of an operating system. It has properties like OSName, Version, FileSystem, IsFirewallEnabled, and NetworkSettings.
The `DisplayConfig()` method is used to print out the configuration details.

* **Builder Interface IOperatingSystemConfigBuilder**:
The `Build()` method returns the final `OperatingSystemConfig` object.

* **Concrete Builder OperatingSystemConfigBuilder**:
The `OperatingSystemConfigBuilder` class implements the `IOperatingSystemConfigBuilder` interface. It maintains an instance of `OperatingSystemConfig` and provides concrete implementations of the methods to set each configuration property.
The builder methods return this to allow for method chaining, which is a common practice in builder pattern implementations.

## Usage

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Building a Linux OS configuration using the builder
        OperatingSystemConfig linuxConfig = new OperatingSystemConfigBuilder()
            .SetOSName("Linux")
            .SetVersion("5.15")
            .SetFileSystem("ext4")
            .EnableFirewall(true)
            .SetNetworkSettings("DHCP")
            .Build();
        linuxConfig.DisplayConfig();

        // Building a Windows OS configuration using the builder
        OperatingSystemConfig windowsConfig = new OperatingSystemConfigBuilder()
            .SetOSName("Windows")
            .SetVersion("11")
            .SetFileSystem("NTFS")
            .EnableFirewall(true)
            .SetNetworkSettings("Static IP")
            .Build();
        windowsConfig.DisplayConfig();
    }
}
```