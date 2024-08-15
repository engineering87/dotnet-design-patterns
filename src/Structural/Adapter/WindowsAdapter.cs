﻿// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Adapter
{
    public class WindowsAdapter : ISystemInfo
    {
        private readonly WindowsOS _windowsOS;

        public WindowsAdapter(WindowsOS windowsOS)
        {
            _windowsOS = windowsOS;
        }

        public string GetSystemDetails()
        {
            // Adapt the WindowsOS interface to the ISystemInfo interface
            return _windowsOS.RetrieveWindowsInfo();
        }
    }
}
