# State Design Pattern
The State design pattern is a behavioral pattern that allows an object to alter its behavior when its internal state changes. It appears as if the object changed its class. This pattern is useful when an object needs to change its behavior based on its state, and it can help in managing state-specific behavior in a cleaner and more organized way.

## Key Concepts of the State Pattern
1. Context:
Definition: The class that maintains a reference to an instance of a State subclass. It is responsible for managing the current state and delegating requests to the current state object.
Purpose: Provides a way to interact with the state and allows state transitions.

2. State Interface (or Abstract State):
Definition: An interface or abstract class that declares methods for handling state-specific behavior. These methods will be implemented by concrete state classes.
Purpose: Defines a common interface for all concrete states and ensures that each state can handle requests in a way that is appropriate for that state.

3. Concrete States:
Definition: Classes that implement the State interface and define the behavior specific to each state. Each concrete state represents a particular state of the context and contains the logic for handling requests in that state.
Purpose: Encapsulates state-specific behavior and manages transitions between states.

4. State Transition:
Definition: The mechanism for changing the state of the context from one state to another. This typically involves updating the context’s state reference to a new instance of a state class.
Purpose: Allows the context to change its behavior dynamically based on its current state.

5. Encapsulation of State-Specific Behavior:
Definition: Each state encapsulates the behavior associated with that state, avoiding the need for large conditional statements in the context class.
Purpose: Enhances code organization and maintainability by separating state-specific logic into distinct classes.

6. Dynamic Behavior Change:
Definition: The pattern allows an object to change its behavior at runtime by switching between states.
Purpose: Enables the object to adapt its behavior based on its current state without requiring modifications to the core logic.

7. Simplified Context Class:
Definition: The context class is simplified as it delegates state-specific behavior to the state objects, thus reducing the complexity of handling multiple states within the context itself.
Purpose: Keeps the context class clean and focused on managing state transitions rather than implementing all state-specific logic.

8. State-Specific Logic:
Definition: Each state class implements behavior relevant to its particular state, leading to a clear and modular design.
Purpose: Ensures that behavior changes in a controlled manner, and new states can be added with minimal impact on existing code.

## Code Explanation
* **State Interface**:
Definition: `IFileState` interface define the methods that concrete states will implement.
Purpose: Declares the state-specific behaviors for opening, closing, and editing a file.

* **Concrete States**:  
    - CreatedState:
        - Purpose: Represents the initial state when the file is created but not yet opened.
        - Behavior: Can transition to the OpenedState when the file is opened. Cannot close or edit.
    - OpenedState:
        - Purpose: Represents the state when the file is open and can be edited.
        - Behavior: Allows the file to be edited and closed. Can transition to ClosedState when closed.
    - ClosedState:
        - Purpose: Represents the state when the file is closed.
        - Behavior: Allows the file to be reopened. Cannot be edited while closed.

* **Context**:
Definition: `FileContext` maintains a reference to the current state and delegates state-specific behavior to the current state object.
Purpose: Manages the current state and provides methods to interact with the file, delegating behavior to the state object.

* **Client Code**:
Creates: An instance of `FileContext` and invokes methods that transition between states and perform actions based on the current state.

## Usage
```csharp
class Program
{
    static void Main(string[] args)
    {
        var file = new FileContext();

        // File is in Created state
        file.Open();  // Transitions to Opened state
        file.Edit();  // Operates in Opened state
        file.Close(); // Transitions to Closed state

        // File is in Closed state
        file.Open();  // Transitions back to Opened state
        file.Edit();  // Operates in Opened state
    }
}
```