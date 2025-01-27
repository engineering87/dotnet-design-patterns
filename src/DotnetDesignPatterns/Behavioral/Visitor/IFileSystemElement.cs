using System;
using System.Collections.Generic;
// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Element Interface
    public interface IFileSystemElement
    {
        void Accept(IFileSystemVisitor visitor);
    }
}
