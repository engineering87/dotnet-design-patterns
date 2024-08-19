// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Singleton.Singleton
{
    public sealed class LazySingleton
    {
        // Lazy<T> is thread-safe by definition and ensures that the instance is created only once.
        private static readonly Lazy<LazySingleton> _instance = new(() => new LazySingleton());

        // Private constructor to prevent instantiation from outside
        private LazySingleton()
        {
            // Initialize the singleton instance
            Console.WriteLine("Singleton instance created");
        }

        // Public static method to get the singleton instance
        public static LazySingleton Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        // Example method
        public void DoSomething()
        {
            Console.WriteLine("Singleton instance is working.");
        }
    }
}
