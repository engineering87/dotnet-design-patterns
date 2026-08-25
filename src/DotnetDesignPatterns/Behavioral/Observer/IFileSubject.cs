// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Observer
{
    /// <summary>
    /// Something that reports file changes to its observers.
    /// </summary>
    public interface IFileSubject
    {
        /// <summary>
        /// Starts sending notifications to this observer.
        /// </summary>
        /// <param name="observer">The observer to register or remove.</param>
        void RegisterObserver(IFileObserver observer);

        /// <summary>
        /// Stops sending notifications to this observer.
        /// </summary>
        /// <param name="observer">The observer to register or remove.</param>
        void UnregisterObserver(IFileObserver observer);

        /// <summary>
        /// Tells every registered observer about a change.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="changeType">What happened to the file, for example created or deleted.</param>
        void NotifyObservers(string fileName, string changeType);
    }
}
