# Creational Design Patterns
Creational design patterns are a subset of design patterns that focus on the process of object creation. Their primary goal is to provide mechanisms for creating objects in a way that is decoupled from the specific classes involved. These patterns abstract the instantiation process, allowing for greater flexibility and control over object creation. Here are the key concepts common to creational design patterns:

## Key Concepts of Creational Design Patterns
1. Encapsulation of Object Creation:
	- **Purpose**: Encapsulates the logic of creating objects to ensure that the client code does not need to know the details of the instantiation process.
	- **Benefit**: Reduces dependencies and promotes loose coupling between the client code and the concrete classes.

2. Abstraction of Object Construction:
	- **Purpose**: Defines a common interface or abstract class for creating objects, allowing subclasses to alter the type of objects that will be created.
	- **Benefit**: Provides flexibility to change the implementation of object creation without affecting the client code.

3. Separation of Concerns:
	- **Purpose**: Separates the responsibility of object creation from other responsibilities, such as business logic or UI management.
	- **Benefit**: Simplifies maintenance and enhances code readability by isolating the object creation logic.

4. Control Over Object Instantiation:
	- **Purpose**: Provides control over how and when objects are created, often including features like lazy initialization, pooling, or caching.
	- **Benefit**: Optimizes performance and resource management by managing object lifecycle and instantiation.

5. Flexibility in Object Creation:
	- **Purpose**: Allows for the creation of different types of objects through a common interface or base class, facilitating changes and extensions.
	- **Benefit**: Supports the addition of new object types with minimal changes to existing code.

## When to Use Creational Patterns
- When the process of creating an object is complex or involves multiple steps.
- When the specific type of object to be created isn’t known until runtime.
- When you want to ensure that objects are created in a consistent way across your system.
- When you want to hide the details of object creation from the client code.
- When you need to enforce constraints on how objects are created and initialized.
- When you want to avoid creating unnecessary objects or want to reuse existing ones.