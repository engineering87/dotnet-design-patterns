// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)

namespace DotnetDesignPatterns.Creational.Factory
{
    public class WindowsOS : IOperatingSystem
    {
        public void Configure()
        {
            Console.WriteLine("Configuring Windows OS with NTFS file system and firewall enabled.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Operating System: Windows");
        }
    }
}
