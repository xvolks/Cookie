using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cookie.API.Core;
using Cookie.API.Core.Pathmanager;
using Cookie.API.Datacenter;
using Cookie.API.Game.Map;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Gamedata.D2p;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.API.Utils.Extensions;
using Cookie.Core.Scripts;
using Cookie.Game.Fight;
using Cookie.Game.Map;
using MoonSharp.Interpreter;
using System.Timers;
using Timer = System.Timers.Timer;
using Cookie.Game.Inventory;

namespace Cookie.Core.Pathmanager
{
    public class MapMovement
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public double MapId { get; set; }
        public bool Fight { get; set; }
        public bool Gather { get; set; }
        public int Door { get; set; }
        public int Path { get; set; }
        public DynValue CustomFunction { get; set; }

        List<MapDirectionEnum> DirectionEnum { get; set; }
        public MapMovement(double mapId)
        {
            MapId = mapId;
            DirectionEnum = new List<MapDirectionEnum>();
            Fight = false;
            Gather = false;
            Door = -1;
            Path = -1;
            CustomFunction = default(DynValue);
        }
        public MapMovement(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
            MapId = -1;
            DirectionEnum = new List<MapDirectionEnum>();
            Fight = false;
            Gather = false;
            Door = -1;
            Path = -1;
            CustomFunction = default(DynValue);
        }
        public MapMovement()
        {
            MapId = -1;
            DirectionEnum = new List<MapDirectionEnum>();
            Fight = false;
            Gather = false;
            Door = -1;
            Path = -1;
        }

        public void AddDirection(MapDirectionEnum direction)
        {
            if (!DirectionEnum.Exists(x => x == direction))
                DirectionEnum.Add(direction);
        }
        public void ClearDirections()
        {
            DirectionEnum.Clear();
        }
        public MapDirectionEnum GetDirectionEnum(Random rand)
        {
            if (DirectionEnum.Count == 0)
                return MapDirectionEnum.Invalid;
            else if (DirectionEnum.Count == 1)
                return DirectionEnum[0];
            return DirectionEnum[rand.Next(DirectionEnum.Count)];
        }
    }

    public class PathManager : IPathManager
    {
        public const string TrajetsDirectory = @"./trajets/";
        Random Randomizer = new Random();
        public int FightCount { get; set; }
        private System.Timers.Timer Timer { get; set; }

        private IMapChangement mapChangement = null;
        public PathManager(IAccount account)
        {
            if (!string.IsNullOrEmpty(TrajetsDirectory) && !Directory.Exists(TrajetsDirectory))
                Directory.CreateDirectory(TrajetsDirectory);

            Launched = false;
            Account = account;
            ScriptData = new List<MapMovement>();
            FightCount = 0;
            /*
            Account.Network.RegisterPacket<MapComplementaryInformationsDataMessage>(
                HandleMapComplementaryInformationsDataMessage, MessagePriority.Normal);
            Account.Network.RegisterPacket<InteractiveUseErrorMessage>(
                HandleInteractiveUseErrorMessage, MessagePriority.Normal);
            Account.Network.RegisterPacket<GameMapNoMovementMessage>(
                HandleGameMapNoMovementMessage, MessagePriority.Normal);
            */
        }
        private List<MapMovement> ScriptData { get; set; }
        private List<int> RessourcesToGather { get; set; }
        private Script script;
        public bool Launched { get; set; }

        public IAccount Account { get; set; }
        private bool Locked { get; set; }
        private int BackUpCellId { get; set; }
        public async void Start(string trajet)
        {
            RessourcesToGather = new List<int>();
            await Task.Run(() => ParseTrajet(TrajetsDirectory + trajet + ".lua"));
            Launched = true;
            if(Timer != null)
                Timer.Enabled = false;
            Timer = new Timer(10000);
            Timer.Elapsed += Timer_Elapsed;
            Timer.AutoReset = false;
            DoAction();
        }

        public void Stop()
        {
            Launched = false;
        }
        public void DoAction()
        {
            if (Locked) return;
            if (Timer.Enabled) return;
            Logger.Default.Log($"DoAction");
            if (!Launched) return;
            mapChangement = null;
            foreach (var movMap in ScriptData)
            {
                if (movMap.MapId == Account.Character.MapId || (movMap.MapId == -1 && 
                    (movMap.PosX == Account.Character.PosX && movMap.PosY == Account.Character.PosY)))
                {
                    StartTimer();
                    if (movMap.Gather && Account.Character.GatherManager.CanGatherOnMap(RessourcesToGather))
                    {
                        Account.Character.GatherManager.Gather(RessourcesToGather, false);
                        return;
                    }else if (movMap.Fight)
                    {
                        if(Account.Character.Map.Monsters.Count > 0 && FightCount < 2)
                        {
                            Account.Character.Fight.FightEnded += Fight_FightEnded;
                            Account.Character.Fight.FightStarted += Fight_FightStarted;
                            Account.Character.Map.LaunchAttack();
                            return;
                        }
                        FightCount = 0;
                        //return; I dont wanna return from here for now because I have the limit fight thing temporally.
                    }else if (movMap.CustomFunction != null && movMap.CustomFunction.IsNotNil() && movMap.CustomFunction.Type == DataType.Function)
                    {
                        script.Call(movMap.CustomFunction); // I can be a lot of things. So after using this user custom function I'll let it timeOut to continue with the script.
                        return;
                    }
                    var mapDir = movMap.GetDirectionEnum(Randomizer);
                    if (mapDir == MapDirectionEnum.Invalid) // there is no present movement on the script.
                        return;
                    else
                        mapChangement = Account.Character.Map.ChangeMap(mapDir);
                    break;
                }
            }
            if (mapChangement == null) return;
            mapChangement.ChangementFinished += MapChangement_ChangementFinished;
            mapChangement.PerformChangement();
        }

        private void MapChangement_ChangementFinished(object sender, MapChangementFinishedEventArgs e)
        {
            if(mapChangement != null)
            {
                mapChangement.ChangementFinished -= MapChangement_ChangementFinished;
                mapChangement = null;
            }
            Locked = false;
            Timer.Enabled = false;
            if (Launched)
                Account.PerformAction(DoAction, 250);
        }

        private void Fight_FightStarted()
        {
            BackUpCellId = Account.Character.CellId;
            Account.Character.Fight.FightStarted -= Fight_FightStarted;
            Timer.Enabled = false;
            Locked = true;
        }

        private void Fight_FightEnded(GameFightEndMessage message)
        {
            Account.Character.Fight.FightEnded -= Fight_FightEnded;
            //Account.Network.SendToServer(new MapInformationsRequestMessage(Account.Character.MapId));
            Account.PerformAction(DoAction, 2000);
            FightCount++;
            Locked = false;
        }


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timer.Elapsed -= Timer_Elapsed;
            Timer.Enabled = false;
            //No action for 10 seconds.
            if (Launched)
                DoAction();
        }
        private void StartTimer()
        {
            if (Timer.Enabled)
                Timer.Enabled = false;
            Timer = new Timer(10000);
            Timer.AutoReset = false;
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }
        private void ParseTrajet(string path)
        {
            script = new Script();

            if (string.IsNullOrEmpty(path) ||
                !File.Exists(path))
                return;

            RessourcesToGather.Clear();
            ScriptData.Clear();

            script.Globals["log"] = (Action<string>)LogMethod;
            script.Globals["Breed"] = (Func<int>)CharacterBreed;
            script.Globals["inv"] = new Inventory(Account, false);

            try
            {
                script.DoFile(path);
            }catch(Exception e)
            {
                Logger.Default.Log($"Exception was thrown at [{path}] => \n {e.Message}");
            }
            #region WhatToGather
            /* What To Gather */
            DynValue Gather = script.Globals.Get("GATHER");
            if (Gather.IsNotNil())
                foreach (var elem in Gather.Table.Values)
                {
                    RessourcesToGather.Add(elem.ToObject<int>());
                }
            #endregion
            #region AI
            /* AI */
            DynValue playPassive = script.Globals.Get("PLAY_PASSIVE");
            ((Character)Account.Character).Ia = new ArtificialIntelligence(playPassive.CastToBool());
            DynValue Spells = script.Call(script.Globals.Get("spells"));
            if (Spells.IsNil())
                throw new Exception("spells cannot be null");
            var spells = new List<IASpell>();
            foreach (var elem in Spells.Table.Values)
            {
                int SpellId = -1;
                int Relaunchs = -1;
                SpellTarget Target = SpellTarget.Enemy;
                bool HandToHand = false;
                bool MoveFirst = false;
                foreach (var pair in elem.Table.Pairs)
                    switch (pair.Key.ToString().ToLower())
                    {
                        case "\"spell\"":
                            SpellId = int.Parse(pair.Value.ToString());
                            break;
                        case "\"target\"":
                            var targettmp = pair.Value.ToString();
                            switch (targettmp.ToLower())
                            {
                                case "\"self\"":
                                    Target = SpellTarget.Self;
                                    break;
                                case "\"enemy\"":
                                    Target = SpellTarget.Enemy;
                                    break;
                                case "\"ally\"":
                                    Target = SpellTarget.Ally;
                                    break;
                            }
                            break;
                        case "\"relaunchs\"":
                        case "\"relaunch\"":
                            Relaunchs = int.Parse(pair.Value.ToString());
                            break;
                        case "\"condition\"":
                            if (pair.Value.CastToString().ToLower() == "close")
                                HandToHand = true;
                            break;
                        case "\"handtohand\"":
                            HandToHand = pair.Value.CastToBool();
                            break;
                        case "\"movefirst\"":
                            MoveFirst = pair.Value.CastToBool();
                            break;
                        default:
                            //Console.WriteLine(@"Erreur: " + key);
                            break;
                    }
                Console.WriteLine($@"Spell ({SpellId}), Target: {Target}, Relaunchs: {Relaunchs}, Condition: "); //{/*script.Call(Condition,110) */}
                if (spells.Exists(x => x.SpellId == SpellId))
                    throw new Exception($"Spell[{SpellId}] has already been added.");
                spells.Add(new IASpell(SpellId, Relaunchs, Target, HandToHand, MoveFirst));
            }
            ((Character)Account.Character).Ia.Load(Account, spells);
            #endregion
            #region Moving
            /* Moving */
            DynValue Move = script.Call(script.Globals["move"]);
            if (Move.IsNotNil())
                foreach (var item in Move.Table.Values)
                {
                    MapMovement newMapMov = new MapMovement();
                    DynValue mapD = item.Table.Get("map");
                    DynValue pathD = item.Table.Get("path");
                    DynValue doorD = item.Table.Get("door");
                    DynValue customFunction = item.Table.Get("custom");
                    if (mapD.IsNil())
                        throw new Exception("map can not be nil.");

                    string map = mapD.CastToString();
                    if (!map.Contains(','))
                    {
                        double.TryParse(map, out double mapId);
                        newMapMov = new MapMovement(mapId);
                    }
                    else
                    {
                        string[] Pos = map.Split(',');
                        if (!(Pos.Length == 2))
                            throw new Exception("Problem Parsing coordinates");
                        if (!int.TryParse(Pos[0], out int posX))
                            throw new Exception("Cannot obtain posX");
                        if (!int.TryParse(Pos[1], out int posY))
                            throw new Exception("Cannot obtain posY");
                        newMapMov = new MapMovement(posX, posY);
                    }

                    if (customFunction.IsNotNil() && customFunction.Type == DataType.Function)
                        newMapMov.CustomFunction = customFunction;
                    if (pathD.IsNil() && doorD.IsNil())
                        Logger.Default.Log($"No path/door on map {(newMapMov.MapId == -1 ? string.Format("{0},{1}", newMapMov.PosX, newMapMov.PosY) : newMapMov.MapId.ToString())}");

                    if (int.TryParse(pathD.CastToString(), out int pathId))
                        newMapMov.Path = pathId; // Just the sun thing in the ground.
                    else if (doorD.IsNotNil())
                        newMapMov.Door = (int)doorD.Number; // We have to interact. 
                    else if(pathD.IsNotNil())
                        try
                        {
                            string[] directions = pathD.CastToString().ToLower().Split(',');
                            foreach(var direction in directions)
                                switch (direction)
                                {
                                    case "top":
                                    case "north":
                                    case "up":
                                        newMapMov.AddDirection(MapDirectionEnum.North);
                                        break;
                                    case "bottom":
                                    case "south":
                                    case "down":
                                        newMapMov.AddDirection(MapDirectionEnum.South);
                                        break;
                                    case "left":
                                    case "west":
                                        newMapMov.AddDirection(MapDirectionEnum.West);
                                        break;
                                    case "right":
                                    case "east":
                                        newMapMov.AddDirection(MapDirectionEnum.East);
                                        break;
                                    default:
                                        break;
                                }
                        }
                        catch (Exception e) { throw new Exception($"Exception thrown parsing Trajet[{e.Message}]"); }
                    

                    if (newMapMov.MapId > 0) //MapId being used
                    {
                        MapPosition tmp = ObjectDataManager.Instance.Get<MapPosition>((uint)newMapMov.MapId);
                        if(ScriptData.Exists(x => x.PosX == tmp.PosX && x.PosY == tmp.PosY) || ScriptData.Exists(x => x.MapId == newMapMov.MapId))
                            throw new PathManagerException($"MapId[{newMapMov.MapId}] or Coordinates[{newMapMov.PosX},{newMapMov.PosY}] duplicated.");
                    }else if (ScriptData.Exists( x => x.PosX == newMapMov.PosX && x.PosY == newMapMov.PosY))
                        throw new PathManagerException($"Coordenates[{newMapMov.PosX},{newMapMov.PosY}] duplicated.");

                    newMapMov.Gather = item.Table.Get("gather").CastToBool();
                    newMapMov.Fight = item.Table.Get("fight").CastToBool();

                    ScriptData.Add(newMapMov);
                }
            #endregion
        }

        private int CharacterBreed()
        {
            return (int)Account.Character.Breed;
        }
        private void LogMethod(string str)
        {
            Logger.Default.Log(str, LogMessageType.Trajet);
        }
    }
}