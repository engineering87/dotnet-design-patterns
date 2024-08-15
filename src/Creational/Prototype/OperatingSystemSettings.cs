// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Prototype
{
    public class OperatingSystemSettings : IPrototype<OperatingSystemSettings>
    {
        public string OSName { get; set; }
        public string Version { get; set; }

        public OperatingSystemSettings(string osName, string version)
        {
            OSName = osName;
            Version = version;
        }

        // Implementazione del metodo Clone
        public OperatingSystemSettings Clone()
        {
            // Clonazione profonda per evitare riferimenti condivisi tra l'originale e il clone
            return new OperatingSystemSettings(OSName, Version);
        }

        // Metodo per visualizzare i dettagli delle impostazioni del sistema operativo
        public void DisplaySettings()
        {
            Console.WriteLine($"OS Name: {OSName}");
            Console.WriteLine($"Version: {Version}");
        }
    }
}
