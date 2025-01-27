// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.TemplateMethod
{
    class CsvFileProcessor : FileProcessor
    {
        private StreamReader _reader;

        protected override void OpenFile(string filePath)
        {
            base.OpenFile(filePath);
            _reader = new StreamReader(filePath);
        }

        protected override string ReadFileContent()
        {
            Console.WriteLine("Reading CSV file content...");
            return _reader.ReadToEnd();
        }

        protected override void ProcessContent(string content)
        {
            Console.WriteLine("Processing CSV file content...");
            // Example of CSV processing: split content by lines
            var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var columns = line.Split(',');
                Console.WriteLine($"Processed CSV line: {string.Join(" | ", columns)}");
            }
        }

        protected override void CloseFile()
        {
            _reader.Close();
            base.CloseFile();
        }
    }
}
