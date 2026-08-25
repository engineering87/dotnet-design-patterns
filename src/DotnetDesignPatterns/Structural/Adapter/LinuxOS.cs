// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Adapter
{
    /// <summary>
    /// An existing class with its own interface, which the caller cannot change.
    /// </summary>
    public class LinuxOS
    {
        /// <summary>
        /// Reports the Linux details in its own shape.
        /// </summary>
        /// <returns>A Linux specific description.</returns>
        public string FetchLinuxInfo()
        {
            return "Ubuntu 20.04 LTS";
        }
    }
}
