using Cookie.Core;

namespace Cookie.Commands.Interfaces
{
    public interface ICommand
    {
        string CommandName { get; }
        void OnCommand(DofusClient client, string[] args);
    }
}