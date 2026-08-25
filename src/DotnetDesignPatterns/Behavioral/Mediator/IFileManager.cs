// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    /// <summary>
    /// The mediator. Colleagues call it instead of calling one another.
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Asks the handler to create the file.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        void CreateFile(string filename);

        /// <summary>
        /// Asks the handler to open the file.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        void OpenFile(string filename);

        /// <summary>
        /// Asks the handler to delete the file.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        void DeleteFile(string filename);

        /// <summary>
        /// Tells the mediator that something happened, so it can react.
        /// </summary>
        /// <param name="sender">The colleague that raised the event.</param>
        /// <param name="eventCode">One of the constants declared in FileEvents.</param>
        void Notify(object sender, string eventCode);
    }
}
