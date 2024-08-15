// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)

namespace DotnetDesignPatterns.Structural.Facade
{
    // Facade
    public class FileManagerFacade
    {
        private FileReader _fileReader;
        private FileWriter _fileWriter;
        private FileValidator _fileValidator;

        public FileManagerFacade()
        {
            _fileReader = new FileReader();
            _fileWriter = new FileWriter();
            _fileValidator = new FileValidator();
        }

        public void ProcessFile(string filePath, string newContent)
        {
            if (_fileValidator.Validate(filePath))
            {
                string content = _fileReader.ReadFile(filePath);
                Console.WriteLine($"Current content: {content}");
                _fileWriter.WriteFile(filePath, newContent);
                Console.WriteLine("File processed successfully.");
            }
            else
            {
                Console.WriteLine("File validation failed.");
            }
        }
    }
}
