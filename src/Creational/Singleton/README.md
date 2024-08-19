# Singleton Design Pattern
The Singleton Design Pattern is a creational design pattern that ensures a class has only one instance and provides a global point of access to that instance. This pattern is useful when exactly one object is needed to coordinate actions across the system.
This repository presents two solutions for creating a Singleton in C#: the **Lazy** approach and the **Lock-based** approach.
Both methods ensure that only one instance of the Singleton class is created, but the Lazy approach is generally preferred for its simplicity and built-in thread safety.

## Key Concepts of the Singleton Pattern
1. Single Instance:
The primary goal of the Singleton Pattern is to restrict the instantiation of a class to a single instance. This is useful when exactly one object is needed to coordinate actions across the system.
The class itself controls its instantiation, ensuring that only one instance is created.

2. Private Constructor:
To prevent other classes from creating instances of the Singleton class directly, the constructor is made private.
This ensures that no other class or object can instantiate the Singleton class outside of its own implementation.

3. Static Instance Variable:
A static variable is used to hold the single instance of the class. This static instance is shared across all instances of the class, making it accessible globally.
The static variable ensures that the single instance is created and maintained throughout the application’s lifecycle.

4. Global Access Method:
A public static method (often named `GetInstance()` or `Instance()`) provides access to the single instance of the class. This method creates the instance if it does not already exist and returns it.
It provides a controlled access point to the instance, ensuring that all clients use the same object.

5. Lazy Initialization (Optional):
To delay the creation of the Singleton instance until it is actually needed, improving performance and resource utilization.
Often used in combination with thread-safety mechanisms to ensure that the instance is created only once even in multithreaded environments.

6. Thread Safety (Optional):
In multithreaded applications, thread safety ensures that the Singleton instance is created only once, even when multiple threads are trying to access it simultaneously.
Various techniques like synchronization, double-checked locking, or using thread-safe constructs (e.g., `Lazy<T>` in C#) are employed to maintain thread safety.

## Code Explanation
* **Lazy Initialization**:
The `Lazy<T>` property ensures that the Singleton instance is only created when it is first accessed. This approach avoids unnecessary resource usage by delaying the creation of the object until it's actually needed.

* **Thread-Safe**:
By using `Lazy<T>`, the Singleton instance is guaranteed to be thread-safe without requiring explicit locks or other synchronization mechanisms. This simplifies the code and improves performance in concurrent environments.

* **Instance Property**:
The Instance property provides access to the single instance of the Singleton. The use of `Lazy<T>` ensures that the instance is created only on the first access and that all subsequent requests use the same instance.

* **Private Constructor**:
The class constructor is private, preventing external code from creating multiple instances of the LazySingleton class. This is crucial to ensure that only one instance of the Singleton exists.

* **Resource Management**:
The `DoSomething` method is examples of how the Singleton might manage shared resources. For instance, a database connection or file access could be centralized in this Singleton, ensuring that resources are managed correctly and safely.

## Usage
### Lazy Singleton
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Accessing the singleton instance
        LazySingleton singleton = LazySingleton.Instance;

        // Using the resources managed by the singleton
        singleton.DoSomething();
    }
}
```

## Usage
### Lock Singleton
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Access the singleton instance
        LockSingleton singleton = LockSingleton.Instance;

        // Using the resources managed by the singleton
        singleton.DoSomething();
    }
}
```