// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Adapter
{
    public class LinuxAdapter : ISystemInfo
    {
        private readonly LinuxOS _linuxOS;

        public LinuxAdapter(LinuxOS linuxOS)
        {
            _linuxOS = linuxOS;
        }

        public string GetSystemDetails()
        {
            // Adapt the LinuxOS interface to the ISystemInfo interface
            return _linuxOS.FetchLinuxInfo();
        }
    }
}
