// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Adapter
{
    /// <summary>
    /// Presents WindowsOS through the interface the caller expects.
    /// </summary>
    public class WindowsAdapter : ISystemInfo
    {
        private readonly WindowsOS _windowsOS;

        /// <summary>
        /// Wraps the Windows implementation.
        /// </summary>
        /// <param name="windowsOS">The Windows implementation being adapted.</param>
        public WindowsAdapter(WindowsOS windowsOS)
        {
            ArgumentNullException.ThrowIfNull(windowsOS);

            _windowsOS = windowsOS;
        }

        /// <summary>
        /// Translates the Windows call into the expected shape.
        /// </summary>
        /// <returns>A description of the system.</returns>
        public string GetSystemDetails()
        {
            // Adapt the WindowsOS interface to the ISystemInfo interface
            return _windowsOS.RetrieveWindowsInfo();
        }
    }
}
