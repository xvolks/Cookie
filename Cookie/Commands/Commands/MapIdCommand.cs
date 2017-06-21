using Cookie.Commands.Interfaces;
using Cookie.Core;
using Cookie.Gamedata;

namespace Cookie.Commands.Commands
{
    public class MapIdCommand : ICommand
    {
        public string CommandName => "mapid";

        public void OnCommand(DofusClient client, string[] args)
        {
            client.Logger.Log($"MapID : {client.Account.Character.MapId} | [{D2OParsing.GetMapCoordinates(client.Account.Character.MapId).X};{D2OParsing.GetMapCoordinates(client.Account.Character.MapId).Y}]",
                LogMessageType.Admin);
        }
    }
}