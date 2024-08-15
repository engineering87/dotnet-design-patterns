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