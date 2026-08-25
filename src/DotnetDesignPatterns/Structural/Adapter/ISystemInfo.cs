// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Adapter
{
    /// <summary>
    /// The interface the caller wants to work with.
    /// </summary>
    public interface ISystemInfo
    {
        /// <summary>
        /// Reports the system details in the shape the caller expects.
        /// </summary>
        /// <returns>A description of the system.</returns>
        string GetSystemDetails();
    }
}
