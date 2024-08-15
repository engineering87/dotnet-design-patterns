// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Iterator
{
    // Iterator Interface
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

}
