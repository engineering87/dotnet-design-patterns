// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)

namespace DotnetDesignPatterns.Creational.Factory
{
    public class LinuxOS : IOperatingSystem
    {
        public void Configure()
        {
            Console.WriteLine("Configuring Linux OS with ext4 file system and firewall enabled.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Operating System: Linux");
        }
    }
}
