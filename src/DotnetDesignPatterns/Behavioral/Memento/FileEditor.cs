// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Memento
{
    // Originator: The File being edited
    public class FileEditor
    {
        public string Content { get; private set; }

        public void Write(string content)
        {
            Content = content;
            Console.WriteLine($"File content updated to: {Content}");
        }

        public FileMemento Save()
        {
            Console.WriteLine("Saving current file state.");
            return new FileMemento(Content);
        }

        public void Restore(FileMemento memento)
        {
            Content = memento.Content;
            Console.WriteLine($"Restored file content to: {Content}");
        }
    }
}
