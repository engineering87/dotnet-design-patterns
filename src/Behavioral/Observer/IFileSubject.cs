// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Observer
{
    // Subject Interface
    public interface IFileSubject
    {
        void RegisterObserver(IFileObserver observer);
        void UnregisterObserver(IFileObserver observer);
        void NotifyObservers(string fileName, string changeType);
    }
}
