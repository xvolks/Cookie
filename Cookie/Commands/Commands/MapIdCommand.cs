using System;
using Cookie.Commands.Interfaces;
using Cookie.Core;
using Cookie.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class MapIdCommand : ICommand
    {
        public string CommandName => "mapid";

        public void OnCommand(DofusClient client, string[] args)
        {
                client.Logger.Log("MapID : " + client.Account.Character.MapId,
                    LogMessageType.Admin);           
        }
    }
}
