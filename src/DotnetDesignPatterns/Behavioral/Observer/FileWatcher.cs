// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Observer
{
    // Concrete Subject: File Watcher
    /// <summary>
    /// The concrete subject. It watches a directory and notifies its observers. Events arrive on thread pool threads, so the observer list is guarded.
    /// </summary>
    public class FileWatcher : IFileSubject, IDisposable
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        private readonly List<IFileObserver> _observers = new();

        // FileSystemWatcher raises its events on thread pool threads, so registration
        // can run concurrently with notification. List<T> does not support that, and the
        // lock below keeps the collection from being mutated while it is enumerated.
        private readonly object _observersLock = new();

        private FileSystemWatcher? _fileSystemWatcher;
        private bool _disposed;

        /// <summary>
        /// Starts sending notifications to this observer.
        /// </summary>
        /// <param name="observer">The observer to register or remove.</param>
        public void RegisterObserver(IFileObserver observer)
        {
            ArgumentNullException.ThrowIfNull(observer);

            lock (_observersLock)
            {
                _observers.Add(observer);
            }
        }

        /// <summary>
        /// Stops sending notifications to this observer.
        /// </summary>
        /// <param name="observer">The observer to register or remove.</param>
        public void UnregisterObserver(IFileObserver observer)
        {
            ArgumentNullException.ThrowIfNull(observer);

            lock (_observersLock)
            {
                _observers.Remove(observer);
            }
        }

        /// <summary>
        /// Notifies a snapshot of the observers taken under the lock.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="changeType">What happened to the file, for example created or deleted.</param>
        public void NotifyObservers(string fileName, string changeType)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
            ArgumentException.ThrowIfNullOrWhiteSpace(changeType);

            IFileObserver[] snapshot;

            lock (_observersLock)
            {
                snapshot = _observers.ToArray();
            }

            // Observers are notified outside the lock, so that a slow or reentrant
            // observer cannot block registration or deadlock the watcher.
            foreach (var observer in snapshot)
            {
                observer.Update(fileName, changeType);
            }
        }

        /// <summary>
        /// Starts watching a directory, replacing any earlier watch.
        /// </summary>
        /// <param name="path">The directory to watch.</param>
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

            Output.WriteLine($"Started watching directory: {path}");
        }

        /// <summary>
        /// Stops watching and releases the underlying watcher.
        /// </summary>
        public void StopWatching()
        {
            if (_fileSystemWatcher != null)
            {
                _fileSystemWatcher.EnableRaisingEvents = false;
                _fileSystemWatcher.Dispose();
                _fileSystemWatcher = null;
            }
        }

        /// <summary>
        /// Stops watching and releases everything this instance holds.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the watcher when called from Dispose.
        /// </summary>
        /// <param name="disposing">True when called from Dispose, false when called from a finalizer.</param>
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
