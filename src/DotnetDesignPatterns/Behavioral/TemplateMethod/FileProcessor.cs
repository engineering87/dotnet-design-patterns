// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.TemplateMethod
{
    // Abstract class defining the Template Method.
    // The class is public so that the test project can exercise it directly.
    /// <summary>
    /// Fixes the order of the processing steps and leaves the steps themselves to the subclasses.
    /// </summary>
    public abstract class FileProcessor
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Runs the four steps in the order this class defines.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        public void ProcessFile(string filePath)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

            OpenFile(filePath);
            var content = ReadFileContent();
            ProcessContent(content);
            CloseFile();
        }

        // Steps of the algorithm, some of which must be overridden by subclasses

        /// <summary>
        /// Opens the file. Subclasses extend this to create their reader.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        protected virtual void OpenFile(string filePath)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

            Output.WriteLine($"Opening file: {filePath}");
        }

        /// <summary>
        /// Reads the content of the file.
        /// </summary>
        /// <returns>Everything the file holds.</returns>
        protected abstract string ReadFileContent();

        /// <summary>
        /// Does whatever this processor does with the content.
        /// </summary>
        /// <param name="content">The content to write.</param>
        protected abstract void ProcessContent(string content);

        /// <summary>
        /// Releases whatever OpenFile acquired.
        /// </summary>
        protected virtual void CloseFile()
        {
            Output.WriteLine("Closing file.");
        }
    }
}
