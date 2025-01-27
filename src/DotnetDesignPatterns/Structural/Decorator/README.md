# Decorator Design Pattern
The Decorator Design Pattern is a structural pattern that allows you to dynamically add behavior to objects by wrapping them with additional functionality. This pattern is useful for extending the functionality of objects without modifying their structure.

## Key Concepts of the Decorator Pattern
1. Component:
Defines the interface or abstract class for objects that can have responsibilities added to them dynamically. This is the common interface or base class that both the concrete component and decorators will implement.
Provides a contract for the concrete components and decorators, allowing them to be used interchangeably.

2. Concrete Component:
Implements the base behavior of the component. This is the core class that is being extended or decorated.
Contains the basic functionality and is typically a simple class that fulfills the component contract.

3. Decorator Base Class:
An abstract class or interface that inherits from the Component. It contains a reference to a Component object and delegates operations to this object.
Provides the foundation for concrete decorators. It usually implements the Component interface and holds a reference to a component instance that it wraps.

4. Concrete Decorators:
Extend the functionality of the Component by adding new behavior. Each concrete decorator adds its own specific behavior to the component.
Implements the Component interface and enhances the behavior of the base component. It modifies or extends the functionality by performing additional operations before or after delegating to the wrapped component.

## Abstract vs Interface
Decorator pattern can be created either using an abstract class or using an interface.

* Use an **interface** if you need flexibility, lightweight design, and are okay with implementing all behavior in each decorator.
    * **Pros**:
        * **Simplicity**: Interfaces are straightforward and easy to understand. They define a clear contract that any decorator must implement.
        * **Flexibility**: A class can implement multiple interfaces, allowing the decorator to work in multiple contexts.
        * **Lightweight**: Interfaces do not carry implementation logic, making them lightweight.Provides flexibility to implement multiple interfaces.

    * **Cons**:
        * **No Shared Behavior**: Interfaces cannot define any shared behavior among decorators, so all shared logic must be repeated or handled externally.
        * **More Boilerplate Code**: If many decorators share common behavior, you may end up duplicating code across multiple classes.

* Use an **abstract class** if you have common behavior to share among decorators and don’t need the flexibility of multiple inheritance.
    * **Pros**: 
        * **Shared Behavior**: An abstract class can provide default implementations or shared behavior that all decorators can inherit and reuse.
        * **Ease of Maintenance**: Common functionality can be centralized in the abstract class, reducing duplication and making the code easier to maintain.
    * **Cons**:
        * **Limited Flexibility**: Since C# does not support multiple inheritance, a class can only extend one abstract class. This might limit the ability to combine the Decorator pattern with other inheritance-based patterns.
        * **More Complex Hierarchy**: Using abstract classes can lead to a more complex class hierarchy, which can increase the difficulty of understanding and maintaining the code.

* Combine **both** if you want to enforce a contract via an interface while still leveraging shared behavior through an abstract class.

The choice depends on your specific requirements, including how much behavior is shared between decorators and how flexible your design needs to be.

## Code Explanation
* **Component**:
Class `Notification` defines the base abstract class for the notification. This is the contract that all concrete and decorator classes will implement.

* **Concrete Component**:
Class `BasicNotification` implements the basic notification functionality. This is the core notification that other decorators will enhance.

* **Decorator Base Class**:
`NotificationDecorator` is an abstract class that extends the `Notification` class and holds a reference to a `Notification` object. It delegates the Send method to the wrapped notification.

* **Concrete Decorators**:
Classes `LoggingDecorator`, `EncryptionDecorator`, `PrioritizationDecorator` implement additional functionality by extending the `NotificationDecorator` class. Each decorator adds a specific feature (logging, encryption, prioritization) to the notification.

## Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create a basic notification
        Notification basicNotification = new BasicNotification();

        // Wrap the basic notification with logging functionality
        Notification loggingNotification = new LoggingDecorator(basicNotification);

        // Wrap the logging notification with encryption functionality
        Notification encryptedNotification = new EncryptionDecorator(loggingNotification);

        // Wrap the encrypted notification with prioritization functionality
        Notification prioritizedNotification = new PrioritizationDecorator(encryptedNotification);

        // Send a notification with all decorators applied
        prioritizedNotification.Send("System alert!");
    }
}
```