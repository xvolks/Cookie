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
            var pos = D2OParsing.GetMapCoordinates(client.Account.Character.MapId);
            Logger.Default.Log($"MapID : {client.Account.Character.MapId} | [{pos.X};{pos.Y}]",
                LogMessageType.Admin);
        }
    }
}