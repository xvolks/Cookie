using System;
using System.Collections.Generic;
using System.IO;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Game.Pathmanager;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Pathmanager
{
    public class PathManager : IPathManager
    {
        private Dictionary<int, Tuple<MapDirectionEnum, string>> PathData { get; set; }
        

        public bool Launched { get; set; }

        public ICharacter Character { get; set; }

        public PathManager(string trajet, ICharacter character)
        {
            Launched = false;
            Character = character;
            PathData = new Dictionary<int, Tuple<MapDirectionEnum, string>>();
            ParseTrajet(trajet);
        }

        private void ParseTrajet(string path)
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
                    case "haut":
                        direction = MapDirectionEnum.North;
                        break;
                    case "bot":
                    case "bas":
                        direction = MapDirectionEnum.South;
                        break;
                    case "left":
                    case "gauche":
                        direction = MapDirectionEnum.West;
                        break;
                    case "right":
                    case "droite":
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

        public void Start()
        {
            Launched = true;
            DoAction();
        }

        public void Stop() => Launched = false;

        public void DoAction()
        {
            if (!Launched) return;
            if (PathData.ContainsKey(Character.MapId))
            {
                switch (PathData[Character.MapId].Item2)
                {
                    case "move":
                        Logger.Default.Log($"[PathManager] Déplacement vers {PathData[Character.MapId].Item1}", LogMessageType.Info);
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
            }
            else
                Logger.Default.Log($"Map {Character.MapId} non gérée dans le trajet");
        }
    }
}
