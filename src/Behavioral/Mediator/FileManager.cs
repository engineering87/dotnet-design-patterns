// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    // Concrete Mediator
    public class FileManager : IFileManager
    {
        private readonly FileExplorer _fileExplorer;
        private readonly FileOperationHandler _fileOperationHandler;
        private readonly Logger _logger;

        public FileManager(FileExplorer fileExplorer, FileOperationHandler fileOperationHandler, Logger logger)
        {
            _fileExplorer = fileExplorer;
            _fileOperationHandler = fileOperationHandler;
            _logger = logger;

            _fileExplorer.SetMediator(this);
            _fileOperationHandler.SetMediator(this);
            _logger.SetMediator(this);
        }

        public void CreateFile(string filename)
        {
            _fileOperationHandler.CreateFile(filename);
        }

        public void OpenFile(string filename)
        {
            _fileOperationHandler.OpenFile(filename);
        }

        public void DeleteFile(string filename)
        {
            _fileOperationHandler.DeleteFile(filename);
        }

        public void Notify(object sender, string eventCode)
        {
            switch (eventCode)
            {
                case "FileCreated":
                    _logger.Log($"File created: {((FileExplorer)sender).CurrentFile}");
                    break;
                case "FileOpened":
                    _logger.Log($"File opened: {((FileExplorer)sender).CurrentFile}");
                    break;
                case "FileDeleted":
                    _logger.Log($"File deleted: {((FileExplorer)sender).CurrentFile}");
                    break;
            }
        }
    }
}
