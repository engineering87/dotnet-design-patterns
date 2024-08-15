// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Proxy
{
    // Real Subject
    public class Resource : IResource
    {
        public void Access()
        {
            // Simulate accessing a resource
            Console.WriteLine("Accessing the real resource.");
        }
    }
}
