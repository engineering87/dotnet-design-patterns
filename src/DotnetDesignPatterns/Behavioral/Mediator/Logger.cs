// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    // Colleague: Logger
    /// <summary>
    /// A colleague that records what the mediator reports.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        private readonly List<string> _entries = new();

        // The mediator is assigned after construction, so the field is nullable.
        private IFileManager? _mediator;

        // The messages logged so far, in order, so that the collaboration between the
        // colleagues can be observed without capturing the console.

        /// <summary>
        /// The messages logged so far, in order.
        /// </summary>
        public IReadOnlyList<string> Entries => _entries;

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
        /// Records a message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void Log(string message)
        {
            ArgumentNullException.ThrowIfNull(message);

            _entries.Add(message);
            Output.WriteLine($"[LOG]: {message}");
        }
    }
}
