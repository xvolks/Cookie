using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.Core;
using Cookie.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class ChangeMapCommand : ICommand
    {
        public string CommandName => "changemap";

        public void OnCommand(IDofusClient client, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log("Vous devez spécifier la direction pour changer de map (left, right, top, bottom).",
                    LogMessageType.Public);
            }
            else
            {
                if (client.Account.Character.Status == CharacterStatus.None)
                    client.Account.Character.Map.ChangeMap(args[0]);
            }
        }
    }
}