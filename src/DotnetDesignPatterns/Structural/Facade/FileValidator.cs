// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Facade
{
    // Subsystem 3: File Validator
    public class FileValidator
    {
        public bool Validate(string filePath)
        {
            // Simulate file validation
            Console.WriteLine($"Validating file at {filePath}");
            return true;
        }
    }
}
