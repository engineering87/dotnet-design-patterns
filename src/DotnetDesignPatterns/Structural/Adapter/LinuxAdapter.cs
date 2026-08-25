// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Adapter
{
    /// <summary>
    /// Presents LinuxOS through the interface the caller expects.
    /// </summary>
    public class LinuxAdapter : ISystemInfo
    {
        private readonly LinuxOS _linuxOS;

        /// <summary>
        /// Wraps the Linux implementation.
        /// </summary>
        /// <param name="linuxOS">The Linux implementation being adapted.</param>
        public LinuxAdapter(LinuxOS linuxOS)
        {
            ArgumentNullException.ThrowIfNull(linuxOS);

            _linuxOS = linuxOS;
        }

        /// <summary>
        /// Translates the Linux call into the expected shape.
        /// </summary>
        /// <returns>A description of the system.</returns>
        public string GetSystemDetails()
        {
            // Adapt the LinuxOS interface to the ISystemInfo interface
            return _linuxOS.FetchLinuxInfo();
        }
    }
}
