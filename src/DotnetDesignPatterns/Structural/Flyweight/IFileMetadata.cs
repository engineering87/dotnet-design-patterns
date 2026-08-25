// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Flyweight
{
    /// <summary>
    /// The shared part of a file description, held once and reused.
    /// </summary>
    public interface IFileMetadata
    {
        /// <summary>
        /// Writes the shared metadata.
        /// </summary>
        void DisplayFileInfo();
    }
}
