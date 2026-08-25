// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.TemplateMethod
{
    /// <summary>
    /// Processes a CSV file line by line.
    /// </summary>
    public class CsvFileProcessor : FileProcessor
    {
        // The reader is opened by OpenFile, one step of the template, so it does
        // not exist yet when the instance is constructed.
        private StreamReader? _reader;

        /// <summary>
        /// Opens a reader over the file.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        protected override void OpenFile(string filePath)
        {
            // The base step validates the path before the reader is opened.
            base.OpenFile(filePath);
            _reader = new StreamReader(filePath);
        }

        /// <summary>
        /// Reads the whole file.
        /// </summary>
        /// <returns>The text the file holds.</returns>
        protected override string ReadFileContent()
        {
            Output.WriteLine("Reading CSV file content...");
            return _reader?.ReadToEnd() ?? string.Empty;
        }

        /// <summary>
        /// Splits the text into lines and columns.
        /// </summary>
        /// <param name="content">The content to write.</param>
        protected override void ProcessContent(string content)
        {
            ArgumentNullException.ThrowIfNull(content);

            Output.WriteLine("Processing CSV file content...");
            // Example of CSV processing: split content by lines
            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var columns = line.Split(',');
                Output.WriteLine($"Processed CSV line: {string.Join(" | ", columns)}");
            }
        }

        /// <summary>
        /// Disposes the reader.
        /// </summary>
        protected override void CloseFile()
        {
            _reader?.Dispose();
            _reader = null;
            base.CloseFile();
        }
    }
}
