// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Proxy
{
    /// <summary>
    /// The interface shared by the real resource and by its proxy.
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Uses the resource.
        /// </summary>
        void Access();
    }
}
