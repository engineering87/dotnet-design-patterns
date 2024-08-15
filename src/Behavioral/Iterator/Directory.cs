// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Iterator
{
    // Concrete Element: Directory
    public class Directory : IFileSystemElement, IFileSystemCollection
    {
        public string Name { get; }
        private readonly List<IFileSystemElement> _elements;

        public Directory(string name)
        {
            Name = name;
            _elements = new List<IFileSystemElement>();
        }

        public void AddElement(IFileSystemElement element)
        {
            _elements.Add(element);
        }

        public IIterator<IFileSystemElement> CreateIterator()
        {
            return new FileSystemIterator(_elements);
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Directory: {Name}");
        }

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
