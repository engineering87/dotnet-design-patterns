// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Observer
{
    // Concrete Subject: File Watcher
    public class FileWatcher : IFileSubject
    {
        private readonly List<IFileObserver> _observers = new List<IFileObserver>();

        public void RegisterObserver(IFileObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnregisterObserver(IFileObserver observer)
        {
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
            var fileSystemWatcher = new FileSystemWatcher(path)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
            };

            fileSystemWatcher.Created += (sender, args) => NotifyObservers(args.FullPath, "created");
            fileSystemWatcher.Changed += (sender, args) => NotifyObservers(args.FullPath, "modified");
            fileSystemWatcher.Deleted += (sender, args) => NotifyObservers(args.FullPath, "deleted");

            fileSystemWatcher.EnableRaisingEvents = true;

            Console.WriteLine($"Started watching directory: {path}");
        }
    }
}
