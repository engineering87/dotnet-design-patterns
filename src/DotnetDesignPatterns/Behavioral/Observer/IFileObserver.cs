// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Observer
{
    /// <summary>
    /// Something that wants to hear about file changes.
    /// </summary>
    public interface IFileObserver
    {
        /// <summary>
        /// Called by the subject when a file has changed.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="changeType">What happened to the file, for example created or deleted.</param>
        void Update(string fileName, string changeType);
    }
}
