// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Composite
{
    /// <summary>
    /// The common interface of a leaf and of a branch, so a client can treat them the same way.
    /// </summary>
    public abstract class FileSystemComponent
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// The name of this component.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Names the component.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        protected FileSystemComponent(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Name = name;
        }

        /// <summary>
        /// Writes this component, indented by the given depth.
        /// </summary>
        /// <param name="depth">The indentation depth used when printing the tree.</param>
        public abstract void Display(int depth);

        /// <summary>
        /// Computes the size of this component.
        /// </summary>
        /// <returns>The size in bytes.</returns>
        public abstract long CalculateSize();
    }
}
