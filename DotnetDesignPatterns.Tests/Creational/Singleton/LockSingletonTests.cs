// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
using DotnetDesignPatterns.Creational.Singleton;

namespace DotnetDesignPatterns.Tests.Creational.Singleton
{
    public class LockSingletonTests
    {
        [Fact]
        public void Instance_ShouldReturnSameInstance()
        {
            // Arrange & Act
            var instance1 = LockSingleton.Instance;
            var instance2 = LockSingleton.Instance;

            // Assert
            Assert.Same(instance1, instance2);
        }

        [Fact]
        public void DoSomething_ShouldExecuteWithoutErrors()
        {
            // Arrange
            var instance = LockSingleton.Instance;

            // Act & Assert
            var exception = Record.Exception(() => instance.DoSomething());

            Assert.Null(exception);
        }

        [Fact]
        public void Instance_ShouldBeThreadSafe()
        {
            // Arrange
            LockSingleton instance1 = null;
            LockSingleton instance2 = null;

            // Act
            var thread1 = new Thread(() => instance1 = LockSingleton.Instance);
            var thread2 = new Thread(() => instance2 = LockSingleton.Instance);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            // Assert
            Assert.NotNull(instance1);
            Assert.NotNull(instance2);
            Assert.Same(instance1, instance2);
        }
    }
}
