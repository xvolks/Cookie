using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class PathCommand : ICommand
    {
        public string CommandName => "path";
        public string ArgsName => "string [on|off], <pathPath>";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
                Logger.Default.Log("Erreur argument command .path", LogMessageType.Public);
            else
                switch (args[0])
                {
                    case "on":
                        if (string.IsNullOrEmpty(args[1]))
                        {
                            Logger.Default.Log("Vous devez indiquer le nom de votre fichier trajet.",
                                LogMessageType.Public);
                        }
                        else
                        {
                            account.Character.PathManager.Start(args[1]);
                            Logger.Default.Log("[PathManager] Lancé !");
                        }
                        break;
                    case "off":
                        if (account.Character.PathManager.Launched)
                        {
                            account.Character.PathManager.Stop();
                            Logger.Default.Log("[PathManager] Arrété !");
                        }
                        else
                        {
                            Logger.Default.Log("Aucun trajet démarré.", LogMessageType.Public);
                        }
                        break;
                    default:
                        Logger.Default.Log("Erreur command .path", LogMessageType.Public);
                        break;
                }
        }
    }
}