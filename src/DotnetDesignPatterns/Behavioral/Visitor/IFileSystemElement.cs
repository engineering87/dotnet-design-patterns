// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Collections.Generic;
// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    /// <summary>
    /// An element that accepts a visitor. Adding an operation means adding a visitor, not changing this type.
    /// </summary>
    public interface IFileSystemElement
    {
        /// <summary>
        /// Lets the visitor operate on this element.
        /// </summary>
        /// <param name="visitor">The visitor that will operate on this element.</param>
        void Accept(IFileSystemVisitor visitor);
    }
}
