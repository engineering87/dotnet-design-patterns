// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Visitor
{
    // Concrete Visitor: Size Calculation
    /// <summary>
    /// A visitor that adds up the size of everything it walks.
    /// </summary>
    public class SizeCalculationVisitor : IFileSystemVisitor
    {
        /// <summary>
        /// The size accumulated so far.
        /// </summary>
        public long TotalSize { get; private set; }

        /// <summary>
        /// Adds the size of the file to the total.
        /// </summary>
        /// <param name="file">The file being visited.</param>
        public void Visit(File file)
        {
            ArgumentNullException.ThrowIfNull(file);

            TotalSize += file.Size;
        }

        /// <summary>
        /// Walks into the directory.
        /// </summary>
        /// <param name="directory">The directory being visited.</param>
        public void Visit(Directory directory)
        {
            ArgumentNullException.ThrowIfNull(directory);

            // Optionally, do something with the directory
        }
    }
}
