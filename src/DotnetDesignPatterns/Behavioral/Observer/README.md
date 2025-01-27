# Observer Design Pattern
The Observer design pattern is a behavioral pattern that defines a one-to-many dependency between objects. When one object changes its state, all its dependents (observers) are notified and updated automatically. This pattern is particularly useful for implementing distributed event-handling systems.

## Key Concepts of the Observer Pattern
1. Subject:
Definition: The Subject is the object whose state changes and needs to notify its observers about these changes.
Responsibilities: It maintains a list of observers and provides methods for attaching, detaching, and notifying them.
Interface: The Subject typically defines methods like `Attach()`, `Detach()`, and `Notify()` for managing observers.

2. Observer:
Definition: The Observer is an object that depends on the Subject and gets notified of any state changes in the Subject.
Responsibilities: It defines the `Update()` method that gets called by the Subject when there is a change.
Interface: Observers implement a common interface that the Subject can use to notify them of changes.

3. Concrete Subject:
Definition: A Concrete Subject is a specific implementation of the Subject interface.
Responsibilities: It maintains the state and notifies all registered observers about state changes.

4. Concrete Observer:
Definition: A Concrete Observer is a specific implementation of the Observer interface.
Responsibilities: It performs the necessary actions when notified of a state change by the Subject.

5. Dependents Notification:
Notification: The Subject automatically informs all registered Observers when its state changes. This is done through the Notify() method, which iterates over the list of observers and calls their Update() method.

6. Decoupling:
Loose Coupling: The Observer pattern promotes loose coupling between the Subject and its Observers. The Subject does not need to know details about the Observers, only that they implement the Observer interface.
Flexibility: New Observers can be added or removed without modifying the Subject, and the Subject does not need to know about specific implementations of Observers.

7. Dynamic Updates:
Real-Time Notification: Observers are updated in real time as soon as the Subject’s state changes, making it suitable for scenarios where timely updates are crucial.
Consistency: Ensures that all registered Observers have the most recent state information from the Subject.

8. Multiple Observers:
One-to-Many Relationship: The pattern supports having multiple Observers for a single Subject. All Observers are notified of any change, ensuring that all dependent objects are kept in sync with the Subject's state.

9. State Management:
Centralized Updates: The Subject is responsible for managing its state and notifying Observers, which simplifies state management and keeps the update mechanism centralized.

## Code Explanation
* **Observer Interface**:
`IFileObserver` defines the Update method that will be called when the observed object (subject) changes its state.
Implemented by concrete observers to handle file change notifications.

* **Concrete Observers**:
`ConsoleLogger` logs file changes to the console.
`EmailNotifier` simulates sending an email notification about file changes.
Both observers implement the Update method from the `IFileObserver` interface.

* **Subject Interface**:
`IFileSubject` defines methods to register, unregister, and notify observers.
Concrete subjects will implement this interface to manage the observer list and send notifications.

* **Concrete Subject**:
`FileWatcher` implements the `IFileSubject` interface.
Uses a `FileSystemWatcher` to monitor changes in a specified directory.
Notifies all registered observers about file creation, modification, or deletion events.

## Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create FileWatcher (Subject)
        var fileWatcher = new FileWatcher();

        // Create Observers
        var consoleLogger = new ConsoleLogger();
        var emailNotifier = new EmailNotifier();

        // Register Observers
        fileWatcher.RegisterObserver(consoleLogger);
        fileWatcher.RegisterObserver(emailNotifier);

        // Start watching a directory
        fileWatcher.StartWatching(@"C:\Temp");

        // Keep the application running to monitor file changes
        Console.WriteLine("Press 'q' to quit.");
        while (Console.Read() != 'q') ;
    }
}
```