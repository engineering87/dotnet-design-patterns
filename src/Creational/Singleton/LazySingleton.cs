// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Singleton.Singleton
{
    public sealed class LazySingleton
    {
        // Lazy<T> è thread-safe per definizione e garantisce la creazione dell'istanza una sola volta.
        private static readonly Lazy<LazySingleton> _instance = new(() => new LazySingleton());

        // Costruttore privato per evitare l'uso del costruttore esterno.
        private LazySingleton()
        {
            // Inizializzazione delle risorse o configurazioni se necessario
        }

        // Proprietà pubblica per accedere all'istanza
        public static LazySingleton Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        // Metodo dimostrativo per il Singleton
        public void DoSomething()
        {
            Console.WriteLine("Singleton instance is working.");
        }
    }
}
