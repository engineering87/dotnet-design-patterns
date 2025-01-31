// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Singleton
{
    public sealed class LockSingleton
    {
        // Private static instance of the Singleton class
        private static LockSingleton? _instance = null;
        // Object used for locking
        private static readonly object _lock = new();

        // Private constructor to prevent instantiation from outside
        private LockSingleton()
        {
            // Initialize the singleton instance
        }

        // Public static method to get the singleton instance
        public static LockSingleton Instance
        {
            get
            {
                // Check if the instance is null
                if (_instance == null)
                {
                    // Lock to ensure that only one thread can enter this block at a time
                    lock (_lock)
                    {
                        // Double-check if the instance is still null
                        // Create the singleton instance
                        _instance ??= new LockSingleton();
                    }
                }
                // Return the singleton instance
                return _instance;
            }
        }

        // Example method
        public void DoSomething()
        {
            // Do something
        }
    }
}
