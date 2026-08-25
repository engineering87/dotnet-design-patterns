// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    // Colleague: File Explorer
    /// <summary>
    /// A colleague that selects a file and asks the mediator to act on it.
    /// </summary>
    public class FileExplorer
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        // The mediator is assigned after construction, so the field is nullable.
        private IFileManager? _mediator;

        // No file is selected until SelectFile is called.

        /// <summary>
        /// The selected file, or null when nothing is selected.
        /// </summary>
        public string? CurrentFile { get; private set; }

        /// <summary>
        /// Attaches this colleague to a mediator.
        /// </summary>
        /// <param name="mediator">The mediator that coordinates the colleagues.</param>
        public void SetMediator(IFileManager mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);
            _mediator = mediator;
        }

        /// <summary>
        /// Selects the file that the next operation will act on.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public void SelectFile(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            CurrentFile = filename;
            Output.WriteLine($"File selected: {filename}");
        }

        /// <summary>
        /// Asks the mediator to create the selected file.
        /// </summary>
        public void CreateFile()
        {
            // A colleague acts only when it is attached to a mediator and a file is selected.
            if (_mediator is null || string.IsNullOrEmpty(CurrentFile))
            {
                return;
            }

            _mediator.CreateFile(CurrentFile);
            _mediator.Notify(this, FileEvents.FileCreated);
        }

        /// <summary>
        /// Asks the mediator to open the selected file.
        /// </summary>
        public void OpenFile()
        {
            if (_mediator is null || string.IsNullOrEmpty(CurrentFile))
            {
                return;
            }

            _mediator.OpenFile(CurrentFile);
            _mediator.Notify(this, FileEvents.FileOpened);
        }

        /// <summary>
        /// Asks the mediator to delete the selected file.
        /// </summary>
        public void DeleteFile()
        {
            if (_mediator is null || string.IsNullOrEmpty(CurrentFile))
            {
                return;
            }

            _mediator.DeleteFile(CurrentFile);
            _mediator.Notify(this, FileEvents.FileDeleted);
        }
    }
}
