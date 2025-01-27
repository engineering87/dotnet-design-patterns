// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Builder
{
    public interface IOperatingSystemConfigBuilder
    {
        IOperatingSystemConfigBuilder SetOSName(string osName);
        IOperatingSystemConfigBuilder SetVersion(string version);
        IOperatingSystemConfigBuilder SetFileSystem(string fileSystem);
        IOperatingSystemConfigBuilder EnableFirewall(bool enable);
        IOperatingSystemConfigBuilder SetNetworkSettings(string networkSettings);
        OperatingSystemConfig Build();
    }
}
