// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Iterator
{
    // Concrete Element: Directory
    /// <summary>
    /// A directory that holds elements and hands out an iterator over them.
    /// </summary>
    public class Directory : IFileSystemElement, IFileSystemCollection
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// The name of the directory.
        /// </summary>
        public string Name { get; }
        private readonly List<IFileSystemElement> _elements;

        /// <summary>
        /// Creates an empty directory with the given name.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        public Directory(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Name = name;
            _elements = new List<IFileSystemElement>();
        }

        /// <summary>
        /// Adds an element to the directory.
        /// </summary>
        /// <param name="element">The element to add to the collection.</param>
        public void AddElement(IFileSystemElement element)
        {
            ArgumentNullException.ThrowIfNull(element);

            _elements.Add(element);
        }

        /// <summary>
        /// Creates an iterator over the elements of this directory.
        /// </summary>
        /// <returns>A fresh iterator.</returns>
        public IIterator<IFileSystemElement> CreateIterator()
        {
            return new FileSystemIterator(_elements);
        }

        /// <summary>
        /// Writes a short description of the directory.
        /// </summary>
        public void PrintDetails()
        {
            Output.WriteLine($"Directory: {Name}");
        }

        // The iterator is private and reachable only through CreateIterator, so a
        // caller cannot build one over a collection it does not own.
        private class FileSystemIterator : IIterator<IFileSystemElement>
        {
            private readonly List<IFileSystemElement> _elements;
            private int _currentIndex;

            public FileSystemIterator(List<IFileSystemElement> elements)
            {
                _elements = elements;
                _currentIndex = 0;
            }

            public bool HasNext()
            {
                return _currentIndex < _elements.Count;
            }

            public IFileSystemElement Next()
            {
                if (!HasNext())
                    throw new InvalidOperationException("No more elements.");

                return _elements[_currentIndex++];
            }
        }
    }
}
