// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Flyweight
{
    /// <summary>
    /// The flyweight. Its state is shared by every file with the same type and owner, so it has to stay immutable.
    /// </summary>
    public class FileMetadata : IFileMetadata
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        private string _fileType;
        private string _owner;

        /// <summary>
        /// Creates the shared metadata for one type and owner pair.
        /// </summary>
        /// <param name="fileType">The extension shared by the files that use this metadata.</param>
        /// <param name="owner">The owner shared by the files that use this metadata.</param>
        public FileMetadata(string fileType, string owner)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileType);
            ArgumentException.ThrowIfNullOrWhiteSpace(owner);

            _fileType = fileType;
            _owner = owner;
        }

        /// <summary>
        /// Writes the shared metadata.
        /// </summary>
        public void DisplayFileInfo()
        {
            Output.WriteLine($"File Type: {_fileType}, Owner: {_owner}");
        }
    }
}
