# Design Patterns Implemented in .NET C#
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![issues - dotnet-design-patterns](https://img.shields.io/github/issues/engineering87/dotnet-design-patterns)](https://github.com/engineering87/dotnet-design-patterns/issues)
[![Language - C#](https://img.shields.io/static/v1?label=Language&message=C%23&color=blueviolet)](https://dotnet.microsoft.com/it-it/languages/csharp)
[![stars - dotnet-design-patterns](https://img.shields.io/github/stars/engineering87/dotnet-design-patterns?style=social)](https://github.com/engineering87/dotnet-design-patterns)

This repository showcases .NET C# Design Patterns. The patterns can be browsed by their high-level descriptions or by looking at their source code. Each design pattern category has its own formal description and each pattern is represented with concrete examples in order to prove the effectiveness of their use.

## Contents
- [What Are Design Patterns?](#what-are-design-patterns)
- [GoF Design Patterns](#gof-design-patterns)
- [Categories of Design Patterns](#categories-of-design-patterns)
  - [Creational Patterns](#creational-patterns)
  - [Structural Patterns](#structural-patterns)
  - [Behavioral Patterns](#behavioral-patterns)
- [Importance of Design Patterns](#importance-of-design-patterns)
- [Why Use Design Patterns?](#why-use-design-patterns)
- [Patterns vs. Anti-patterns](#patterns-vs-anti-patterns)
- [.NET and Design Patterns](#net-and-design-patterns)
- [Repository Layout](#repository-layout)
- [How to Contribute](#how-to-contribute)
- [Examples and Use Cases](#examples-and-use-cases)
- [Licensee](#licensee)
- [Contact](#contact)

## What Are Design Patterns?
Design patterns are **standardized solutions** to common problems encountered in Software Design. They provide reusable templates for solving recurring design issues in a way that promotes best practices and improves the overall architecture of a Software System. Design patterns are not code snippets but rather general concepts that can be adapted to specific needs. They help in creating systems that are **modular**, **maintainable**, and **scalable** by defining best practices for structuring code and handling various aspects of software design.

## GoF Design Patterns
The **GoF (Gang of Four)** design patterns refer to a collection of 23 design patterns that were introduced in the book **"Design Patterns: Elements of Reusable Object-Oriented Software"** published in 1994 by four authors: *Erich Gamma*, *Richard Helm*, *Ralph Johnson*, and *John Vlissides*. This book became a cornerstone in the field of software engineering and introduced the concept of design patterns as a systematic approach to solving common design problems.

[Design Patterns: Elements of Reusable Object-Oriented Software](https://en.wikipedia.org/wiki/Design_Patterns)

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

## .NET and Design Patterns
The .NET platform, especially with C#, offers rich language features (like delegates, LINQ, async/await, and dependency injection) that make many design patterns more expressive and efficient to implement. Patterns like Dependency Injection, Singleton, Factory, and Observer are commonly used in .NET-based enterprise solutions and are well-supported by frameworks like ASP.NET Core and libraries like `Microsoft.Extensions.*`
In this repository, each pattern is demonstrated using idiomatic C# to reflect best practices in the .NET ecosystem.

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

## Licensee
Repository source code is available under MIT License, see license in the source.

## Contact
Please contact at francesco.delre.87[at]gmail.com for any details.
