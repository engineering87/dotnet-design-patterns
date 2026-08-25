// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Observer
{
    // Concrete Observer 1: Console Logger
    /// <summary>
    /// An observer that writes each change.
    /// </summary>
    public class ConsoleLogger : IFileObserver
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Writes the change.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="changeType">What happened to the file, for example created or deleted.</param>
        public void Update(string fileName, string changeType)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
            ArgumentException.ThrowIfNullOrWhiteSpace(changeType);

            Output.WriteLine($"[Console Logger] File {fileName} has been {changeType}.");
        }
    }
}
