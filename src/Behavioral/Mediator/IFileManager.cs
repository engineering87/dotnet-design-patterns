// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.Mediator
{
    // Mediator Interface
    public interface IFileManager
    {
        void CreateFile(string filename);
        void OpenFile(string filename);
        void DeleteFile(string filename);
        void Notify(object sender, string eventCode);
    }
}
