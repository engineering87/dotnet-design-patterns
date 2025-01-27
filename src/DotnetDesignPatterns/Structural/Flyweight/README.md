# Flyweight Design Pattern

The Flyweight Design Pattern is a structural pattern that reduces the memory usage by sharing common parts of objects. It is particularly useful when dealing with a large number of objects that share a common state. The Flyweight Pattern helps to optimize memory usage by avoiding the creation of duplicate objects that share similar data.

## Key Concepts of the Flyweight Pattern

1. Flyweight Interface:
Defines the common interface for all flyweight objects. This interface provides methods that the flyweight objects must implement, ensuring that they can be used interchangeably.
The interface specifies the operations that can be performed on the flyweight objects. This ensures that both concrete flyweights and the client code can interact with the objects in a uniform manner.

2. Concrete Flyweight:
Implements the flyweight interface and contains the intrinsic state (shared state) that is common across multiple instances. Intrinsic state is immutable and shared among flyweight instances.
Provides the actual implementation of the flyweight operations and stores the data that is shared among multiple objects. The concrete flyweight does not manage any unique state specific to individual instances.

3. Intrinsic State:
Represents the part of the object's state that is shared and can be shared among multiple objects. Intrinsic state is stored in the concrete flyweight and is consistent across all instances of the flyweight.
This state is stored within the flyweight objects and is reused across different contexts to save memory.

4. Extrinsic State:
Represents the part of the object's state that varies and is not shared. This state is managed by the client code and is provided to the flyweight when needed. Extrinsic state is not stored in the flyweight objects but is passed as parameters or provided externally.
Managed outside the flyweight and is provided to the flyweight objects during operations. This allows the flyweight to work with varying data without having to store it internally.

5. Flyweight Factory:
Manages the creation and sharing of flyweight objects. It maintains a cache or pool of existing flyweight instances to ensure that duplicate objects are not created unnecessarily.
Responsible for checking if a flyweight instance already exists in the cache. If it does, the factory returns the existing instance; otherwise, it creates a new one and adds it to the cache.

## Code Explanation

* **Flyweight Interface**:
IFileMetadata defines the common interface that all flyweight objects will implement. It ensures that all concrete flyweights adhere to a uniform interface for displaying file information.

* **Concrete Flyweight**:
FileMetadata implements the flyweight interface and contains the shared state (metadata) for files, such as file type and owner. This class does not store any unique state specific to individual file instances.

* **Flyweight Factory**:
FileMetadataFactory manages the creation and sharing of flyweight instances. It maintains a cache of existing flyweight objects to avoid creating duplicates. If the required flyweight object is already in the cache, it reuses the existing instance; otherwise, it creates a new one.

## Usage

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Create a proxy with restricted access
        IResource proxyWithRestrictedAccess = new ResourceProxy("Guest");
        proxyWithRestrictedAccess.Access(); // Should deny access

        // Create a proxy with admin access
        IResource proxyWithAdminAccess = new ResourceProxy("Admin");
        proxyWithAdminAccess.Access(); // Should grant access
    }
}
```