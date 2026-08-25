// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Facade
{
    // Subsystem 3: File Validator
    /// <summary>
    /// One of the subsystem classes the facade hides.
    /// </summary>
    public class FileValidator
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Checks that the path can be used.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>True when the path is usable.</returns>
        public bool Validate(string filePath)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

            // Simulate file validation
            Output.WriteLine($"Validating file at {filePath}");
            return true;
        }
    }
}
