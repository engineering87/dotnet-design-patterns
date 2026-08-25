// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    /// <summary>
    /// The concrete mediator. It wires the colleagues together and holds every rule about how they interact.
    /// </summary>
    public class FileManager : IFileManager
    {
        private readonly FileExplorer _fileExplorer;
        private readonly FileOperationHandler _fileOperationHandler;
        private readonly Logger _logger;

        /// <summary>
        /// Attaches every colleague to this mediator.
        /// </summary>
        /// <param name="fileExplorer">The colleague that selects the file to act on.</param>
        /// <param name="fileOperationHandler">The colleague that performs the file operations.</param>
        /// <param name="logger">The colleague that records what happened.</param>
        public FileManager(FileExplorer fileExplorer, FileOperationHandler fileOperationHandler, Logger logger)
        {
            ArgumentNullException.ThrowIfNull(fileExplorer);
            ArgumentNullException.ThrowIfNull(fileOperationHandler);
            ArgumentNullException.ThrowIfNull(logger);

            _fileExplorer = fileExplorer;
            _fileOperationHandler = fileOperationHandler;
            _logger = logger;

            // The mediator wires itself to every colleague, so that no colleague
            // ever needs a reference to another colleague.
            _fileExplorer.SetMediator(this);
            _fileOperationHandler.SetMediator(this);
            _logger.SetMediator(this);
        }

        /// <summary>
        /// Forwards a create request to the handler.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public void CreateFile(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            _fileOperationHandler.CreateFile(filename);
        }

        /// <summary>
        /// Forwards an open request to the handler.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public void OpenFile(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            _fileOperationHandler.OpenFile(filename);
        }

        /// <summary>
        /// Forwards a delete request to the handler.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public void DeleteFile(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            _fileOperationHandler.DeleteFile(filename);
        }

        /// <summary>
        /// Turns an event from a colleague into a log entry.
        /// </summary>
        /// <param name="sender">The colleague that raised the event.</param>
        /// <param name="eventCode">One of the constants declared in FileEvents.</param>
        public void Notify(object sender, string eventCode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(eventCode);

            ArgumentNullException.ThrowIfNull(sender);

            if (sender is not FileExplorer explorer)
            {
                return;
            }

            switch (eventCode)
            {
                case FileEvents.FileCreated:
                    _logger.Log($"File created: {explorer.CurrentFile}");
                    break;
                case FileEvents.FileOpened:
                    _logger.Log($"File opened: {explorer.CurrentFile}");
                    break;
                case FileEvents.FileDeleted:
                    _logger.Log($"File deleted: {explorer.CurrentFile}");
                    break;
            }
        }
    }
}
