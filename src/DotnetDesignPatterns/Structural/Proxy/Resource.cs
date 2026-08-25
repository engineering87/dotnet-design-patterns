// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Proxy
{
    /// <summary>
    /// The real subject, which the proxy stands in for.
    /// </summary>
    public class Resource : IResource
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        /// <summary>
        /// Uses the resource for real.
        /// </summary>
        public void Access()
        {
            Output.WriteLine("Accessing the real resource.");
        }
    }
}
