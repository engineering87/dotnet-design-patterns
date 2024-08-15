// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Behavioral.State
{
    // Context
    public class FileContext
    {
        public IFileState State { get; set; }

        public FileContext()
        {
            State = new CreatedState();
        }

        public void Open()
        {
            State.Open(this);
        }

        public void Close()
        {
            State.Close(this);
        }

        public void Edit()
        {
            State.Edit(this);
        }
    }
}
