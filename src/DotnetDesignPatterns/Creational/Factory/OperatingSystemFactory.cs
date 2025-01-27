// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)

namespace DotnetDesignPatterns.Creational.Factory
{
    public static class OperatingSystemFactory
    {
        public static IOperatingSystem CreateOperatingSystem(string osType)
        {
            return osType.ToLower() switch
            {
                "linux" => new LinuxOS(),
                "windows" => new WindowsOS(),
                _ => throw new ArgumentException("Invalid OS Type"),
            };
        }
    }
}
