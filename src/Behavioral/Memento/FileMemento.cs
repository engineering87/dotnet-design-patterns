// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Memento
{
    // Memento: Stores the state of the File
    public class FileMemento
    {
        public string Content { get; }

        public FileMemento(string content)
        {
            Content = content;
        }
    }
}
