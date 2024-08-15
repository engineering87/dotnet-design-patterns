// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Singleton
{
    public sealed class LockSingleton
    {
        private static LockSingleton? _instance = null;
        private static readonly object _lock = new();

        // Costruttore privato per evitare l'uso del costruttore esterno.
        private LockSingleton()
        {
            // Inizializzazione delle risorse o configurazioni se necessario
        }

        // Proprietà pubblica per accedere all'istanza
        public static LockSingleton Instance
        {
            get
            {
                // Doppio controllo del lock per evitare un blocco non necessario
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new LockSingleton();
                    }
                }
                return _instance;
            }
        }

        // Metodo dimostrativo per il Singleton
        public void DoSomething()
        {
            Console.WriteLine("Singleton instance is working.");
        }
    }
}
