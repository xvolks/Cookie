using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Game.Pathmanager;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Pathmanager
{
    public class PathManager : IPathManager
    {
        public const string TrajetsDirectory = @"./trajets/";

        public PathManager(ICharacter character)
        {
            if (!string.IsNullOrEmpty(TrajetsDirectory) && !Directory.Exists(TrajetsDirectory))
                Directory.CreateDirectory(TrajetsDirectory);

            Launched = false;
            Character = character;
            PathData = new Dictionary<int, Tuple<MapDirectionEnum, string>>();
        }

        private Dictionary<int, Tuple<MapDirectionEnum, string>> PathData { get; set; }


        public bool Launched { get; set; }

        public ICharacter Character { get; set; }

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
            if (PathData.ContainsKey(Character.MapId))
                switch (PathData[Character.MapId].Item2)
                {
                    case "move":
                        Logger.Default.Log($"[PathManager] Déplacement vers {PathData[Character.MapId].Item1}",
                            LogMessageType.Info);
                        Character.Map.ChangeMap(PathData[Character.MapId].Item1);
                        break;
                    case "gather":
                        Logger.Default.Log("[PathManager] Récolte non gérée", LogMessageType.Public);
                        Character.Map.ChangeMap(PathData[Character.MapId].Item1);
                        break;
                    case "fight":
                        Logger.Default.Log("[PathManager] Combat non géré", LogMessageType.Public);
                        Character.Map.ChangeMap(PathData[Character.MapId].Item1);
                        break;
                }
            else
                Logger.Default.Log($"Map {Character.MapId} non gérée dans le trajet");
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
                //throw;
            }
        }
    }
}