// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Memento
{
    // Originator: The File being edited
    /// <summary>
    /// The originator. It produces snapshots of itself and restores from them.
    /// </summary>
    public class FileEditor
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// The content currently being edited.
        /// </summary>
        public string Content { get; private set; } = string.Empty;

        /// <summary>
        /// Replaces the content.
        /// </summary>
        /// <param name="content">The content to write.</param>
        public void Write(string content)
        {
            Content = content ?? string.Empty;
            Output.WriteLine($"File content updated to: {Content}");
        }

        /// <summary>
        /// Takes a snapshot of the current content.
        /// </summary>
        /// <returns>A snapshot that can be restored.</returns>
        public FileMemento Save()
        {
            Output.WriteLine("Saving current file state.");
            return new FileMemento(Content);
        }

        /// <summary>
        /// Puts the editor back to the state held by the snapshot.
        /// </summary>
        /// <param name="memento">The snapshot to restore.</param>
        public void Restore(FileMemento memento)
        {
            ArgumentNullException.ThrowIfNull(memento);
            Content = memento.Content;
            Output.WriteLine($"Restored file content to: {Content}");
        }
    }
}
