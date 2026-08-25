// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Creational.Singleton
{
    /// <summary>
    /// A singleton built with double-checked locking, kept as a counterpoint to the Lazy&lt;T&gt; version.
    /// </summary>
    public sealed class LockSingleton
    {
        // The field is volatile because double-checked locking is not guaranteed
        // to be correct by ECMA-335 without it, even though the Microsoft CLR
        // gives release semantics to writes. See CA2002 and the Microsoft guidance
        // on the lazy initialization pattern.
        private static volatile LockSingleton? _instance;
        private static readonly object _lock = new();

        // The constructor is private so that no other instance can be created.
        private LockSingleton()
        {
        }

        /// <summary>
        /// The single instance, created under a lock on first access.
        /// </summary>
        /// <returns>The one instance of the class.</returns>
        public static LockSingleton Instance
        {
            get
            {
                // The fast path: once the instance exists, no lock is taken.
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        // The second check: another thread may have won the race
                        // between the first check and this lock.
                        _instance ??= new LockSingleton();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Stands in for whatever shared resource the singleton owns.
        /// </summary>
        public void DoSomething()
        {
            // Do something
        }
    }
}
