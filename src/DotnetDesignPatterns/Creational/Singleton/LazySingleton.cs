// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Singleton
{
    /// <summary>
    /// A singleton whose instance is created by Lazy&lt;T&gt;, which handles the synchronisation and guarantees that the factory runs once.
    /// </summary>
    public sealed class LazySingleton
    {
        // Lazy<T> is thread-safe by definition and ensures that the instance is created only once.
        private static readonly Lazy<LazySingleton> _instance = new(() => new LazySingleton());

        // The constructor is private so that no other instance can be created.
        private LazySingleton()
        {
        }

        /// <summary>
        /// The single instance, created on first access.
        /// </summary>
        /// <returns>The one instance of the class.</returns>
        public static LazySingleton Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        /// <summary>
        /// Stands in for whatever shared resource the singleton owns.
        /// </summary>
        public void DoSomething()
        {
        }
    }
}
