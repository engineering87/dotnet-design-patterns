// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Observer
{
    // Concrete Subject: File Watcher
    public class FileWatcher : IFileSubject, IDisposable
    {
        private readonly List<IFileObserver> _observers = new List<IFileObserver>();
        private FileSystemWatcher? _fileSystemWatcher;
        private bool _disposed;

        public void RegisterObserver(IFileObserver observer)
        {
            ArgumentNullException.ThrowIfNull(observer);
            _observers.Add(observer);
        }

        public void UnregisterObserver(IFileObserver observer)
        {
            ArgumentNullException.ThrowIfNull(observer);
            _observers.Remove(observer);
        }

        public void NotifyObservers(string fileName, string changeType)
        {
            foreach (var observer in _observers)
            {
                observer.Update(fileName, changeType);
            }
        }

        public void StartWatching(string path)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(path);

            StopWatching();

            _fileSystemWatcher = new FileSystemWatcher(path)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
            };

            _fileSystemWatcher.Created += (sender, args) => NotifyObservers(args.FullPath, "created");
            _fileSystemWatcher.Changed += (sender, args) => NotifyObservers(args.FullPath, "modified");
            _fileSystemWatcher.Deleted += (sender, args) => NotifyObservers(args.FullPath, "deleted");

            _fileSystemWatcher.EnableRaisingEvents = true;

            Console.WriteLine($"Started watching directory: {path}");
        }

        public void StopWatching()
        {
            if (_fileSystemWatcher != null)
            {
                _fileSystemWatcher.EnableRaisingEvents = false;
                _fileSystemWatcher.Dispose();
                _fileSystemWatcher = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    StopWatching();
                }
                _disposed = true;
            }
        }
    }
}
