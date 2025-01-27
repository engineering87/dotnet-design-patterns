// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    // Colleague: File Explorer
    public class FileExplorer
    {
        private IFileManager _mediator;
        public string CurrentFile { get; private set; }

        public void SetMediator(IFileManager mediator)
        {
            _mediator = mediator;
        }

        public void SelectFile(string filename)
        {
            CurrentFile = filename;
            Console.WriteLine($"File selected: {filename}");
        }

        public void CreateFile()
        {
            if (!string.IsNullOrEmpty(CurrentFile))
            {
                _mediator.CreateFile(CurrentFile);
                _mediator.Notify(this, "FileCreated");
            }
        }

        public void OpenFile()
        {
            if (!string.IsNullOrEmpty(CurrentFile))
            {
                _mediator.OpenFile(CurrentFile);
                _mediator.Notify(this, "FileOpened");
            }
        }

        public void DeleteFile()
        {
            if (!string.IsNullOrEmpty(CurrentFile))
            {
                _mediator.DeleteFile(CurrentFile);
                _mediator.Notify(this, "FileDeleted");
            }
        }
    }
}
