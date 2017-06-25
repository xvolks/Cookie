using System;
using System.Collections.Generic;
using Cookie.API.Datacenter;
using Cookie.API.Game.Map;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Gamedata.D2p;
using Cookie.API.Protocol.Network.Messages.Game.Interactive;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Types.Game.Interactive;
using IMap = Cookie.API.Gamedata.D2p.IMap;

namespace Cookie.Game.Map
{
    public class MapData : IMapData
    {
        public MapData()
        {
            Players = new List<GameRolePlayCharacterInformations>();
            Monsters = new List<GameRolePlayGroupMonsterInformations>();
            Npcs = new List<GameRolePlayNpcInformations>();
            Others = new List<GameRolePlayActorInformations>();
            InteractiveElements = new List<InteractiveElement>();
            StatedElements = new List<StatedElement>();
        }

        public List<GameRolePlayCharacterInformations> Players { get; set; }

        public List<GameRolePlayGroupMonsterInformations> Monsters { get; set; }

        public List<GameRolePlayNpcInformations> Npcs { get; set; }

        public List<GameRolePlayActorInformations> Others { get; set; }

        public List<InteractiveElement> InteractiveElements { get; set; }

        public List<StatedElement> StatedElements { get; set; }
        public IMap Data { get; set; }

        public void ParseLocation(int mapId)
        {
            Data = MapsManager.FromId(mapId);
        }

        public void ParseActors(GameRolePlayActorInformations[] actors)
        {
            foreach (var actor in actors)
            {
                if (actor is GameRolePlayCharacterInformations character)
                {
                    Players.Add(character);
                    Console.WriteLine($@"(Player) {character.Name} en cellid ->  {character.Disposition.CellId}");
                    continue;
                }
                if (actor is GameRolePlayGroupMonsterInformations monster)
                {
                    Monsters.Add(monster);
                    var monsterName = FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                        .Get<Monster>(monster.StaticInfos.MainCreatureLightInfos.CreatureGenericId).NameId);
                    Console.WriteLine($@"(Monster) {monsterName} en cellid ->  {monster.Disposition.CellId}");
                    continue;
                }
                if (actor is GameRolePlayNpcInformations npc)
                {
                    Npcs.Add(npc);
                    var npcName =
                        FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Npc>(npc.NpcId).NameId);
                    Console.WriteLine($@"(Npc) {npcName} en cellid ->  {npc.Disposition.CellId}");
                    continue;
                }
                Others.Add(actor);
                Console.WriteLine($@"(Other) Aucune Idée en cellid -> {actor.Disposition.CellId}");
            }
        }

        public void AddActor(GameRolePlayActorInformations actor)
        {
            if (actor is GameRolePlayCharacterInformations character)
            {
                Players.Add(character);
                Console.WriteLine($@"(Player) {character.Name} en cellid ->  {character.Disposition.CellId}");
                return;
            }
            if (actor is GameRolePlayGroupMonsterInformations monster)
            {
                Monsters.Add(monster);
                var monsterName = FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                    .Get<Monster>(monster.StaticInfos.MainCreatureLightInfos.CreatureGenericId).NameId);
                Console.WriteLine($@"(Monster) {monsterName} en cellid ->  {monster.Disposition.CellId}");
                return;
            }
            if (actor is GameRolePlayNpcInformations npc)
            {
                Npcs.Add(npc);
                var npcName =
                    FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Npc>(npc.NpcId).NameId);
                Console.WriteLine($@"(Npc) {npcName} en cellid ->  {npc.Disposition.CellId}");
                return;
            }
            Others.Add(actor);
            Console.WriteLine($@"(Other) Aucune Idée en cellid -> {actor.Disposition.CellId}");
        }

        public void RemoveActor(double contextualId)
        {
            Players.RemoveAll(p => p.ContextualId == contextualId);
            Monsters.RemoveAll(p => p.ContextualId == contextualId);
            Npcs.RemoveAll(p => p.ContextualId == contextualId);
            Others.RemoveAll(p => p.ContextualId == contextualId);
        }

        public void RefreshActor(double contextualId, short cellEnd)
        {
            if (Players.Find(p => p.ContextualId == contextualId) != null)
            {
                Players.Find(p => p.ContextualId == contextualId).Disposition.CellId = cellEnd;
                Console.WriteLine(
                    $@"(Players) {
                            Players.Find(p => p.ContextualId == contextualId).Name
                        } se déplace sur la cellid -> {cellEnd}");
            }
            else if (Monsters.Find(p => p.ContextualId == contextualId) != null)
            {
                Monsters.Find(p => p.ContextualId == contextualId).Disposition.CellId = cellEnd;
                Console.WriteLine($@"(Monsters) se déplace sur la cellid -> {cellEnd}");
            }
            else if (Others.Find(p => p.ContextualId == contextualId) != null)
            {
                Others.Find(p => p.ContextualId == contextualId).Disposition.CellId = cellEnd;
                Console.WriteLine($@"(Others) se déplace sur la cellid -> {cellEnd}");
            }
            else if (Npcs.Find(p => p.ContextualId == contextualId) != null)
            {
                Npcs.Find(p => p.ContextualId == contextualId).Disposition.CellId = cellEnd;
                Console.WriteLine($@"(Npcs) se déplace sur la cellid -> {cellEnd}");
            }
            else
            {
                Console.WriteLine($@"Quelque chose se déplace sur la cellid -> {cellEnd}");
            }
        }

        public void ParseInteractiveElement(InteractiveElement[] elements)
        {
            foreach (var element in elements)
                if (element.OnCurrentMap)
                    InteractiveElements.Add(element);
        }

        public void ParseStatedElement(StatedElement[] elements)
        {
            foreach (var element in elements)
                if (element.OnCurrentMap)
                    StatedElements.Add(element);
        }

        public void UpdateInteractiveElement(InteractiveElementUpdatedMessage update)
        {
            if (!update.InteractiveElement.OnCurrentMap) return;
            InteractiveElements.Remove(
                InteractiveElements.Find(x => x.ElementId == update.InteractiveElement.ElementId));
            InteractiveElements.Add(update.InteractiveElement);
        }

        public void UpdateStatedElement(StatedElementUpdatedMessage update)
        {
            if (!update.StatedElement.OnCurrentMap) return;
            StatedElements.Remove(
                StatedElements.Find(x => x.ElementId == update.StatedElement.ElementId));
            StatedElements.Add(update.StatedElement);
        }

        public bool NoEntitiesOnCell(int cellId)
        {
            return Monsters.Find(p => p.Disposition.CellId == cellId) == null;
        }

        public bool NothingOnCell(int cellId)
        {
            return Data.IsWalkable(cellId) && NoEntitiesOnCell(cellId);
        }

        public void Clear()
        {
            Data = null;
            Players.Clear();
            Monsters.Clear();
            Npcs.Clear();
            Others.Clear();
        }
    }
}