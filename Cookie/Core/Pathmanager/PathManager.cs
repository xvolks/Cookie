using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Game.Pathmanager;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Core.Pathmanager
{
    public class PathManager : IPathManager
    {
        public const string TrajetsDirectory = @"./trajets/";

        public PathManager(IAccount account)
        {
            if (!string.IsNullOrEmpty(TrajetsDirectory) && !Directory.Exists(TrajetsDirectory))
                Directory.CreateDirectory(TrajetsDirectory);

            Launched = false;
            Account = account;
            PathData = new Dictionary<int, Tuple<MapDirectionEnum, string>>();

            Account.Network.RegisterPacket<MapComplementaryInformationsDataMessage>(
                HandleMapComplementaryInformationsDataMessage, MessagePriority.Normal);
        }

        private Dictionary<int, Tuple<MapDirectionEnum, string>> PathData { get; set; }


        public bool Launched { get; set; }

        public IAccount Account { get; set; }

        public async void Start(string trajet)
        {
            await Task.Run(() => ParseTrajet(TrajetsDirectory + trajet + ".txt"));
            Launched = true;
            DoAction();
        }

        public void Stop()
        {
            Launched = false;
        }

        public void DoAction()
        {
            if (!Launched) return;
            if (PathData.ContainsKey(Account.Character.MapId))
                switch (PathData[Account.Character.MapId].Item2)
                {
                    case "move":
                        Logger.Default.Log($"[PathManager] Déplacement vers {PathData[Account.Character.MapId].Item1}",
                            LogMessageType.Info);
                        Account.Character.Map.ChangeMap(PathData[Account.Character.MapId].Item1);
                        break;
                    case "gather":
                        Logger.Default.Log("[PathManager] Récolte non gérée", LogMessageType.Public);
                        Account.Character.Map.ChangeMap(PathData[Account.Character.MapId].Item1);
                        break;
                    case "fight":
                        Logger.Default.Log("[PathManager] Combat non géré", LogMessageType.Public);
                        Account.Character.Map.ChangeMap(PathData[Account.Character.MapId].Item1);
                        break;
                }
            else
                Logger.Default.Log($"Map {Account.Character.MapId} non gérée dans le trajet");
        }

        private void ParseTrajet(string path)
        {
            PathData = new Dictionary<int, Tuple<MapDirectionEnum, string>>();
            try
            {
                var trajet = File.ReadAllLines(path);

                foreach (var line in trajet)
                {
                    var data = line.Split(':');
                    var mapId = Convert.ToInt32(data[0]);
                    var tempDirection = data[1];
                    var action = data[2];

                    var direction = MapDirectionEnum.South;

                    switch (tempDirection)
                    {
                        case "top":
                        case "up":
                        case "haut":
                        case "north":
                            direction = MapDirectionEnum.North;
                            break;
                        case "bot":
                        case "bottom":
                        case "bas":
                        case "south":
                            direction = MapDirectionEnum.South;
                            break;
                        case "left":
                        case "gauche":
                        case "west":
                            direction = MapDirectionEnum.West;
                            break;
                        case "right":
                        case "droite":
                        case "east":
                            direction = MapDirectionEnum.East;
                            break;
                        default:
                            Logger.Default.Log($"Erreur syntaxe {tempDirection} - direction défini sur bas");
                            break;
                    }

                    var tuple = Tuple.Create(direction, action);
                    PathData.Add(mapId, tuple);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void HandleMapComplementaryInformationsDataMessage(IAccount account,
            MapComplementaryInformationsDataMessage message)
        {
            if (Launched)
                DoAction();
        }
    }
}