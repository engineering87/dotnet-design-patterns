# Design Patterns Implemented in .NET C#
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![issues - dotnet-design-patterns](https://img.shields.io/github/issues/engineering87/dotnet-design-patterns)](https://github.com/engineering87/dotnet-design-patterns/issues)
[![Language - C#](https://img.shields.io/static/v1?label=Language&message=C%23&color=blueviolet)](https://dotnet.microsoft.com/it-it/languages/csharp)
[![stars - dotnet-design-patterns](https://img.shields.io/github/stars/engineering87/dotnet-design-patterns?style=social)](https://github.com/engineering87/dotnet-design-patterns)

This repository showcases .NET C# Design Patterns. The patterns can be browsed by their high-level descriptions or by looking at their source code. Each design pattern category has its own formal description and each pattern is represented with concrete examples in order to prove the effectiveness of their use.

## Contents
- [What Are Design Patterns?](#what-are-design-patterns)
- [GoF Design Patterns](#gof-design-patterns)
- [Quickstart](#quickstart)
- [Categories of Design Patterns](#categories-of-design-patterns)
  - [Creational Patterns](#creational-patterns)
  - [Structural Patterns](#structural-patterns)
  - [Behavioral Patterns](#behavioral-patterns)
- [Importance of Design Patterns](#importance-of-design-patterns)
- [Why Use Design Patterns?](#why-use-design-patterns)
- [Overview Table of GoF Patterns](#overview-table-of-gof-patterns)
- [Patterns vs. Anti-patterns](#patterns-vs-anti-patterns)
- [When to Use or Avoid Each Pattern](#when-to-use-or-avoid-each-pattern)
- [.NET and Design Patterns](#net-and-design-patterns)
- [.NET Mapping Cheatsheet](#net-mapping-cheatsheet)
- [Repository Layout](#repository-layout)
- [Examples and Use Cases](#examples-and-use-cases)
- [How to Contribute](#how-to-contribute)
- [Further Reading](#further-reading)
- [License](#license)
- [Contact](#contact)

## What Are Design Patterns?
Design patterns are **standardized solutions** to common problems encountered in Software Design. They provide reusable templates for solving recurring design issues in a way that promotes best practices and improves the overall architecture of a Software System. Design patterns are not code snippets but rather general concepts that can be adapted to specific needs. They help in creating systems that are **modular**, **maintainable**, and **scalable** by defining best practices for structuring code and handling various aspects of software design.

## GoF Design Patterns
The **GoF (Gang of Four)** design patterns refer to a collection of 23 design patterns that were introduced in the book **"Design Patterns: Elements of Reusable Object-Oriented Software"** published in 1994 by four authors: *Erich Gamma*, *Richard Helm*, *Ralph Johnson*, and *John Vlissides*. This book became a cornerstone in the field of software engineering and introduced the concept of design patterns as a systematic approach to solving common design problems.

👉 [Design Patterns: Elements of Reusable Object-Oriented Software](https://en.wikipedia.org/wiki/Design_Patterns)

## Quickstart
Clone the repository and build the project:

```bash
git clone https://github.com/engineering87/dotnet-design-patterns.git
cd dotnet-design-patterns
dotnet build
```

## Categories of Design Patterns
Design patterns are typically categorized into three main types based on their role and purpose:

1. **Creational Patterns**
2. **Structural Patterns**
3. **Behavioral Patterns**

### Creational Patterns
Creational patterns focus on the process of object creation. They deal with how objects are instantiated, which can be a complex process depending on the requirements. These patterns abstract the instantiation process, allowing for more flexible and reusable code.

### Structural Patterns
Structural patterns focus on the composition of classes and objects to form larger structures. They help in defining how objects and classes are composed to form larger structures while ensuring flexibility and efficiency.

### Behavioral Patterns
Behavioral patterns focus on the interactions between objects and how responsibilities are distributed among them. They define how objects communicate and collaborate to perform specific tasks.

## Importance of Design Patterns
By leveraging design patterns, developers can create more robust, maintainable, and scalable software systems. Patterns provide a framework for solving common design problems and ensure that solutions adhere to best practices in software engineering.

1. **Reusability**:
Design patterns provide tested and proven solutions that can be reused across different projects. This reduces the need to reinvent the wheel and helps in creating consistent and reliable solutions.

2. **Maintainability**:
Patterns promote code organization and modularity, making it easier to maintain and update software. By following established patterns, changes to one part of the system can be made with minimal impact on other parts.

3. **Scalability**:
Design patterns help in building scalable systems by promoting best practices and providing guidelines for expanding functionality. They make it easier to add new features or components without disrupting existing code.

4. **Communication**:
Design patterns provide a common vocabulary for developers to discuss and understand solutions to design problems. They facilitate clear communication and collaboration within development teams.

5. **Flexibility**:
Patterns offer ways to handle changing requirements and evolving designs by decoupling components and defining clear responsibilities. This flexibility allows systems to adapt to new needs or technologies more easily.

## Why Use Design Patterns?
Design patterns act as a toolbox of proven solutions, helping developers create better, more efficient, and maintainable software. They offer a structured approach to problem-solving, improve code readability, and facilitate collaboration among team members.

## Overview Table of GoF Patterns

| Pattern | Category | Description |
|---------|----------|-------------|
| **Abstract Factory**  | Creational  | Provide an interface for creating families of related or dependent objects without specifying their concrete classes. |
| **Builder**           | Creational  | Separate the construction of a complex object from its representation so that the same process can create different representations. |
| **Factory Method**    | Creational  | Define an interface for object creation, but let subclasses decide which class to instantiate. |
| **Prototype**         | Creational  | Create new objects by copying an existing object (prototype) rather than creating from scratch. |
| **Singleton**         | Creational  | Ensure a class has only one instance, and provide a global point of access to it. |
| **Adapter**           | Structural  | Allow incompatible interfaces to work together by wrapping one with an adapter. |
| **Bridge**            | Structural  | Decouple an abstraction from its implementation so the two can vary independently. |
| **Composite**         | Structural  | Compose objects into tree structures to represent part-whole hierarchies; clients treat individual objects and compositions uniformly. |
| **Decorator**         | Structural  | Attach additional responsibilities to objects dynamically. |
| **Facade**            | Structural  | Provide a unified interface to a set of interfaces in a subsystem. |
| **Flyweight**         | Structural  | Use sharing to support large numbers of fine-grained objects efficiently. |
| **Proxy**             | Structural  | Provide a surrogate or placeholder for another object to control access or defer costly operations. |
| **Chain of Responsibility** | Behavioral | Allow a request to be passed along a chain of handlers until one handles it. |
| **Command**           | Behavioral | Encapsulate a request as an object, thereby letting you parameterize clients with queues, requests, and operations. |
| **Interpreter**       | Behavioral | Define a representation for a grammar of a language, and an interpreter to deal with this grammar. |
| **Iterator**          | Behavioral | Provide a way to access elements of an aggregate object sequentially without exposing its underlying representation. |
| **Mediator**          | Behavioral | Define an object that encapsulates how a set of objects interact. |
| **Memento**           | Behavioral | Capture and externalize an object’s internal state so that it can be restored later, without breaking encapsulation. |
| **Observer**          | Behavioral | Define a one-to-many dependency so that when one object changes state, all its dependents are notified. |
| **State**             | Behavioral | Allow an object to alter its behavior when its internal state changes; object appears to change class. |
| **Strategy**          | Behavioral | Define a family of algorithms, encapsulate each one, and make them interchangeable. |
| **Template Method**   | Behavioral | Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. |
| **Visitor**           | Behavioral | Represent an operation to be performed on elements of an object structure without changing the classes of the elements. |

## Patterns vs. Anti-patterns
Design patterns and anti-patterns play crucial roles in software development, each representing opposing approaches to solving programming challenges:
- **Design Patterns**:
  - Provide standard solutions for recurring problems in programming.
  - Have been developed and refined over time to create software that is manageable, flexible, and efficient.
  - Help developers produce clean, predictable, and high-quality code.

- **Anti-Patterns**:
  - Represent flawed strategies that initially seem like valid solutions but lead to significant problems over time.
  - Stem from logical fallacies, inexperience, or a desire for quick fixes.
  - Can result in systems that are difficult to maintain, improve, or understand.

- **Causes of Anti-Patterns**:
  - Pressure to deliver quickly, leading to sub-optimal architectural designs.
  - Poor understanding and ineffective communication among team members.
  - Spread of poor design practices, causing numerous bugs and making new code integration challenging.

## When to Use or Avoid Each Pattern
| Pattern | When to Use | When to Avoid |
|---------|-------------|---------------|
| **Abstract Factory** | When you need to create families of related objects without depending on concrete classes. | If you only need a few objects and don’t need family consistency. |
| **Builder** | When constructing a complex object step by step with different representations. | If the object is simple and doesn’t need stepwise construction. |
| **Factory Method** | When subclasses should decide which concrete class to instantiate. | If you don’t need flexibility in instantiation. |
| **Prototype** | When creating new objects by cloning existing ones is cheaper than creating from scratch. | If objects are simple or cloning is more expensive than direct creation. |
| **Singleton** | When exactly one instance must exist and be globally accessible. | If global state leads to hidden dependencies or testing becomes hard. |
| **Adapter** | When you need to make incompatible interfaces work together. | If you can refactor the code to use a common interface instead. |
| **Bridge** | When you want to decouple abstraction from implementation so both can vary. | If the hierarchy is stable and won’t evolve separately. |
| **Composite** | When working with tree structures (part-whole hierarchies) and want uniform access. | If the structure is flat and simple, no hierarchy needed. |
| **Decorator** | When you want to add behavior dynamically without modifying classes. | If object composition makes debugging/maintenance too complex. |
| **Facade** | When you want to simplify a complex subsystem with a unified interface. | If a simple wrapper hides too much functionality needed by clients. |
| **Flyweight** | When you need to handle many similar objects efficiently by sharing state. | If objects are unique and sharing state gives no benefit. |
| **Proxy** | When you want a placeholder to control access (e.g., lazy load, security). | If indirection adds unnecessary complexity or overhead. |
| **Chain of Responsibility** | When multiple handlers can process a request without hardcoding sender–receiver. | If request flow must be predictable and explicit. |
| **Command** | When you need to encapsulate requests, support undo/redo, or queue/log actions. | If direct method calls are simpler and sufficient. |
| **Interpreter** | When you have a grammar to interpret and it’s relatively simple. | If grammar is complex — use a parser/DSL instead. |
| **Iterator** | When you want sequential access to elements without exposing structure. | If simple loops over collections are enough. |
| **Mediator** | When you want to centralize and simplify complex communications between objects. | If communication is simple and a mediator adds indirection. |
| **Memento** | When you need to save and restore object state without exposing internals. | If state saving is too costly in memory or performance. |
| **Observer** | When you want one-to-many notifications of state changes. | If frequent updates cause performance issues or cascading changes. |
| **State** | When an object’s behavior should change based on internal state. | If state changes are rare or can be handled with conditionals. |
| **Strategy** | When you need interchangeable algorithms encapsulated behind a common interface. | If only one algorithm exists and will not change. |
| **Template Method** | When you want to define the skeleton of an algorithm but let subclasses fill steps. | If subclassing leads to rigid inheritance and reduced flexibility. |
| **Visitor** | When you need to perform operations on object structures without modifying them. | If the object structure changes often — adding visitors becomes painful. |

## .NET and Design Patterns
The .NET platform, especially with C#, offers rich language features (like delegates, LINQ, async/await, and dependency injection) that make many design patterns more expressive and efficient to implement. Patterns like Dependency Injection, Singleton, Factory, and Observer are commonly used in .NET-based enterprise solutions and are well-supported by frameworks like ASP.NET Core and libraries like `Microsoft.Extensions.*`
In this repository, each pattern is demonstrated using idiomatic C# to reflect best practices in the .NET ecosystem.

## .NET Mapping Cheatsheet
- **Singleton** → `IServiceCollection.AddSingleton<T>()`, `Lazy<T>`
- **Strategy** → Interfaces + DI, runtime selection via factory/Keyed services
- **Observer** → `IObservable<T>/IObserver<T>`, C# events, `IChangeToken`
- **Decorator** → Multiple registrations / `Scrutor` (service decoration)
- **Adapter** → Wrapper for external SDKs (e.g., HTTP client), `HttpMessageHandler`
- **Factory Method / Abstract Factory** → `IServiceProvider`, factory delegate `Func<T>`
- **Command** → MediatR, `IRequestHandler<>`
- **Iterator** → `IEnumerable<T>`, `yield return`
- **Template Method** → Base classes + `virtual` methods
- **Proxy** → `HttpClient` / generated clients, dynamic proxies (Castle, DispatchProxy)

## Repository Layout
Each design pattern category has its own directory and each pattern inside has its own folder, its description and its source code.

## Examples and Use Cases
Each pattern comes with practical examples demonstrating its application in real-world scenarios. These examples help developers understand when and how to use each pattern to solve specific design problems effectively.

## How to Contribute
Thank you for considering to help out with the source code!
If you'd like to contribute, please fork, fix, commit and send a pull request for the maintainers to review and merge into the main code base.

 * [Setting up Git](https://docs.github.com/en/get-started/getting-started-with-git/set-up-git)
 * [Fork the repository](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/working-with-forks/fork-a-repo)
 * [Open an issue](https://github.com/engineering87/dotnet-design-patterns/issues) if you encounter a bug or have a suggestion for improvements/features

## Further Reading
- [Common Design Patterns (.NET Design Guidelines)](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/common-design-patterns) – Official Microsoft guidance on commonly used design patterns in .NET.  
- [Discovering the Design Patterns You're Already Using in .NET (MSDN Magazine)](https://learn.microsoft.com/en-us/archive/msdn-magazine/2005/july/discovering-the-design-patterns-you-re-already-using-in-net) – An article showing how many design patterns are already embedded in the .NET Framework and ASP.NET.  
- [Design Patterns: Elements of Reusable Object-Oriented Software](https://en.wikipedia.org/wiki/Design_Patterns) – The original “Gang of Four” book that introduced the 23 classic design patterns.  

## License
Repository source code is available under MIT License, see [LICENSE](LICENSE) in the source.

## Contact
Please contact at francesco.delre.87[at]gmail.com for any details.
