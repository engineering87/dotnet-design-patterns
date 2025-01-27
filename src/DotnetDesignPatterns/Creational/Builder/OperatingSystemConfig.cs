// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Builder
{
    public class OperatingSystemConfig
    {
        public string OSName { get; set; }
        public string Version { get; set; }
        public string FileSystem { get; set; }
        public bool IsFirewallEnabled { get; set; }
        public string NetworkSettings { get; set; }

        public void DisplayConfig()
        {
            Console.WriteLine($"Operating System: {OSName}");
            Console.WriteLine($"Version: {Version}");
            Console.WriteLine($"File System: {FileSystem}");
            Console.WriteLine($"Firewall Enabled: {IsFirewallEnabled}");
            Console.WriteLine($"Network Settings: {NetworkSettings}");
            Console.WriteLine();
        }
    }
}
