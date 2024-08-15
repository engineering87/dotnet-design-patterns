# Proxy Design Pattern

The Proxy Design Pattern is a structural pattern that provides a surrogate or placeholder for another object to control access to it. Proxies can be used for various purposes, including access control, lazy initialization, logging, and more. The proxy pattern involves creating an interface or abstract class that both the real subject and proxy class implement, allowing the proxy to act as an intermediary.

## Key Concepts of the Proxy Pattern

1. Subject Interface:
Defines the common interface that both the real subject and proxy will implement. This ensures that both the proxy and the real object can be used interchangeably by the client.
Specifies the methods and properties that the real subject and proxy must implement. This interface provides a consistent way for clients to interact with both the proxy and the real subject.

2. Real Subject:
Represents the actual object that performs the core functionality. It contains the real implementation of the operations defined by the subject interface.
Provides the concrete implementation of the subject interface. This is where the main functionality resides and is used directly by the proxy to perform actions.

3. Proxy:
Acts as an intermediary between the client and the real subject. The proxy controls access to the real subject and can add additional functionality such as access control, logging, or lazy initialization.
Implements the subject interface and holds a reference to the real subject. The proxy forwards client requests to the real subject and can perform additional tasks before or after delegating the request.

## Code Explanation

* **Subject Interface**:
`IResource` defines the common interface that both the real subject (Resource) and the proxy (ResourceProxy) implement. This ensures that both can be used interchangeably.

* **Real Subject**:
Class `Resource` implements the actual resource management functionality. This is where the core operations are performed.

* **Proxy**:
Class `ResourceProxy` controls access to the real subject. It performs additional tasks such as access control, logging, or lazy initialization. In this example, it checks user permissions and initializes the real resource only when needed (lazy initialization).

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