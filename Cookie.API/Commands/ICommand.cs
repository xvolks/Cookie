using Cookie.API.Core;

namespace Cookie.API.Commands
{
    public interface ICommand
    {
        string CommandName { get; }
        void OnCommand(IDofusClient client, string[] args);
    }
}