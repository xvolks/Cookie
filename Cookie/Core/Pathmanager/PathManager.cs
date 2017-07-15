using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cookie.API.Core;
using Cookie.API.Core.Pathmanager;
using Cookie.API.Game.Map;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Messages.Game.Interactive;
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
            Account.Network.RegisterPacket<InteractiveUseErrorMessage>(
                HandleInteractiveUseErrorMessage, MessagePriority.Normal);
            Account.Network.RegisterPacket<GameMapNoMovementMessage>(
                HandleGameMapNoMovementMessage, MessagePriority.Normal);
        }

        private Dictionary<int, Tuple<MapDirectionEnum, string>> PathData { get; set; }
        private List<int> RessourcesToGather { get; set; }

        public bool Launched { get; set; }

        public IAccount Account { get; set; }

        public async void Start(string trajet)
        {
            RessourcesToGather = new List<int>();
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
            IMapChangement mapChangement = null;
            if (PathData.ContainsKey(Account.Character.MapId))
                switch (PathData[Account.Character.MapId].Item2)
                {
                    case "move":
                        Logger.Default.Log($"[PathManager] Déplacement vers {PathData[Account.Character.MapId].Item1}",
                            LogMessageType.Info);
                        mapChangement = Account.Character.Map.ChangeMap(PathData[Account.Character.MapId].Item1);
                        break;
                    case "gather":
                        if (Account.Character.GatherManager.CanGatherOnMap(RessourcesToGather))
                        {
                            Logger.Default.Log("Lancement de la récolte");
                            Account.Character.GatherManager.Gather(RessourcesToGather, false);
                            break;
                        }
                        Logger.Default.Log("Rien a récolter");
                        mapChangement = Account.Character.Map.ChangeMap(PathData[Account.Character.MapId].Item1);
                        break;
                    case "fight":
                        Logger.Default.Log("[PathManager] Combat non géré", LogMessageType.Public);
                        mapChangement = Account.Character.Map.ChangeMap(PathData[Account.Character.MapId].Item1);
                        break;
                }
            else
                Logger.Default.Log($"Map {Account.Character.MapId} non gérée dans le trajet");

            if (mapChangement == null) return;
            mapChangement.ChangementFinished += delegate(object sender, MapChangementFinishedEventArgs args)
            {
                Logger.Default.Log($"Changement de map {args.Success}");
            };
            mapChangement.PerformChangement();
        }

        private void ParseTrajet(string path)
        {
            PathData = new Dictionary<int, Tuple<MapDirectionEnum, string>>();
            try
            {
                var trajet = File.ReadAllLines(path);

                foreach (var line in trajet)
                {
                    if (string.IsNullOrEmpty(line)) continue;

                    if (line.Contains("IdGather"))
                    {
                        var tempLine = line.Split(':');
                        var ids = tempLine[1].Split(',').Select(id => Convert.ToInt32(id)).ToList();
                        RessourcesToGather = ids;
                        continue;
                    }

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
                    PathData.Add(mapId, Tuple.Create(direction, action));
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
                account.PerformAction(DoAction, 1000);
        }

        private void HandleInteractiveUseErrorMessage(IAccount account, InteractiveUseErrorMessage message)
        {
            if (Launched)
                account.PerformAction(DoAction, 1000);
        }

        private void HandleGameMapNoMovementMessage(IAccount account, GameMapNoMovementMessage message)
        {
            if (Launched)
                account.PerformAction(DoAction, 1000);
        }
    }
}