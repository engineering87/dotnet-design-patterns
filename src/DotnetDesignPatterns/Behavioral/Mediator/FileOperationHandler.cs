// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    // Colleague: File Operation Handler
    /// <summary>
    /// A colleague that performs the file operations the mediator asks for.
    /// </summary>
    public class FileOperationHandler
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        private readonly List<string> _operations = new();

        // The mediator is assigned after construction, so the field is nullable.
        private IFileManager? _mediator;

        // The operations performed so far, in order. The console output below makes the
        // example readable when it runs, and this collection is what lets a caller, or a
        // test, observe the behaviour without capturing the console.

        /// <summary>
        /// The operations performed so far, in order.
        /// </summary>
        public IReadOnlyList<string> Operations => _operations;

        // A colleague knows whether it has been attached to a mediator.

        /// <summary>
        /// Whether a mediator has been attached.
        /// </summary>
        public bool IsAttached => _mediator is not null;

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
        /// Performs a create operation.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public void CreateFile(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            Record($"Creating file: {filename}");
        }

        /// <summary>
        /// Performs an open operation.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public void OpenFile(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            Record($"Opening file: {filename}");
        }

        /// <summary>
        /// Performs a delete operation.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        public void DeleteFile(string filename)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filename);

            Record($"Deleting file: {filename}");
        }

        private void Record(string operation)
        {
            _operations.Add(operation);
            Output.WriteLine(operation);
        }
    }
}
