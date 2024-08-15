// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.TemplateMethod
{
    // Abstract class defining the Template Method
    abstract class FileProcessor
    {
        // Template Method
        public void ProcessFile(string filePath)
        {
            OpenFile(filePath);
            var content = ReadFileContent();
            ProcessContent(content);
            CloseFile();
        }

        // Steps of the algorithm, some of which must be overridden by subclasses
        protected virtual void OpenFile(string filePath)
        {
            Console.WriteLine($"Opening file: {filePath}");
        }

        protected abstract string ReadFileContent();

        protected abstract void ProcessContent(string content);

        protected virtual void CloseFile()
        {
            Console.WriteLine("Closing file.");
        }
    }
}
