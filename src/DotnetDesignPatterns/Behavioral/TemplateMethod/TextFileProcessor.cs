// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.TemplateMethod
{
    // Concrete class for processing text files
    class TextFileProcessor : FileProcessor
    {
        private StreamReader _reader;

        protected override void OpenFile(string filePath)
        {
            base.OpenFile(filePath);
            _reader = new StreamReader(filePath);
        }

        protected override string ReadFileContent()
        {
            Console.WriteLine("Reading text file content...");
            return _reader.ReadToEnd();
        }

        protected override void ProcessContent(string content)
        {
            Console.WriteLine("Processing text file content...");
            // Simple example of content processing
            var processedContent = content.ToUpper();
            Console.WriteLine($"Processed content: {processedContent}");
        }

        protected override void CloseFile()
        {
            _reader.Close();
            base.CloseFile();
        }
    }
}
