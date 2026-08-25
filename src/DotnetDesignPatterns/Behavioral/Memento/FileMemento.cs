// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Memento
{
    // Memento: Stores the state of the File
    /// <summary>
    /// A snapshot of the editor state. It carries the content and nothing else, so the caretaker cannot reach into the originator.
    /// </summary>
    public class FileMemento
    {
        /// <summary>
        /// The content captured when the snapshot was taken.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Captures the given content.
        /// </summary>
        /// <param name="content">The content to write.</param>
        public FileMemento(string content)
        {
            ArgumentNullException.ThrowIfNull(content);

            Content = content;
        }
    }
}
