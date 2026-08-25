// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Adapter
{
    /// <summary>
    /// An existing class with its own interface, which the caller cannot change.
    /// </summary>
    public class WindowsOS
    {
        /// <summary>
        /// Reports the Windows details in its own shape.
        /// </summary>
        /// <returns>A Windows specific description.</returns>
        public string RetrieveWindowsInfo()
        {
            return "Windows 10, Version 21H1";
        }
    }
}
