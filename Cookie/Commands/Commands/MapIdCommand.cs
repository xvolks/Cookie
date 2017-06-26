using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Gamedata;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class MapIdCommand : ICommand
    {
        public string CommandName => "mapid";

        public void OnCommand(IDofusClient client, string[] args)
        {
            var pos = D2OParsing.GetMapCoordinates(client.Account.Character.MapId);
            Logger.Default.Log($"MapID : {client.Account.Character.MapId} | [{pos.X};{pos.Y}]",
                LogMessageType.Admin);
        }
    }
}