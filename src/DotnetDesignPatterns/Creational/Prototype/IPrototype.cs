// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Prototype
{
    public interface IPrototype<T>
    {
        T Clone();
    }
}
