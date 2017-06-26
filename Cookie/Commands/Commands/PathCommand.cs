using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class PathCommand : ICommand
    {
        public string CommandName => "path";

        public void OnCommand(IDofusClient client, string[] args)
        {
            if (args.Length < 1)
                client.Log("Erreur argument command .path", LogMessageType.Public);
            else
                switch (args[0])
                {
                    case "on":
                        if (string.IsNullOrEmpty(args[1]))
                        {
                            client.Log("Vous devez indiquer le nom de votre fichier trajet.", LogMessageType.Public);
                        }
                        else
                        {
                            client.Account.Character.PathManager.Start(args[1]);
                            client.Log("[PathManager] Lancé !");
                        }
                        break;
                    case "off":
                        if (client.Account.Character.PathManager.Launched)
                        {
                            client.Account.Character.PathManager.Stop();
                            client.Log("[PathManager] Arrété !");
                        }
                        else
                        {
                            client.Log("Aucun trajet démarré.", LogMessageType.Public);
                        }
                        break;
                    default:
                        client.Log("Erreur command .path", LogMessageType.Public);
                        break;
                }
        }
    }
}