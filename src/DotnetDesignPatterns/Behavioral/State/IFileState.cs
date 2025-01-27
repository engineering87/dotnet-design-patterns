// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.State
{
    // State Interface
    public interface IFileState
    {
        void Open(FileContext context);
        void Close(FileContext context);
        void Edit(FileContext context);
    }
}
