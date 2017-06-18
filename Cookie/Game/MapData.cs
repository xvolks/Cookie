using Cookie.Datacenter;
using Cookie.Gamedata.D2o;
using Cookie.Gamedata.I18n;
using Cookie.Protocol.Network.Types.Game.Context.Roleplay;
using System;
using System.Collections.Generic;

namespace Cookie.Game.Map
{
    public class MapData
    {
        public Dictionary<double, GameRolePlayCharacterInformations> Players { get; set; }

        public Dictionary<double, GameRolePlayGroupMonsterInformations> Monsters { get; set; }

        public Dictionary<double, GameRolePlayNpcInformations> Npcs { get; set; }

        public Dictionary<double, GameRolePlayActorInformations> Others { get; set; }

        public MapData()
        {
            Players = new Dictionary<double, GameRolePlayCharacterInformations>();
            Monsters = new Dictionary<double, GameRolePlayGroupMonsterInformations>();
            Npcs = new Dictionary<double, GameRolePlayNpcInformations>();
            Others = new Dictionary<double, GameRolePlayActorInformations>();
        }

        public void ParseActors(GameRolePlayActorInformations[] actors)
        {
            foreach (var actor in actors)
            {
                if (actor is GameRolePlayCharacterInformations character)
                {
                    Players.Add(character.ContextualId, character);
                    Console.WriteLine($@"(Player) {character.Name} en cellid ->  {character.Disposition.CellId}");
                    continue;
                }
                if (actor is GameRolePlayGroupMonsterInformations monster)
                {
                    Monsters.Add(monster.ContextualId, monster);
                    var monsterName = I18nDataManager.Instance.ReadText(ObjectDataManager.Instance
                        .Get<Monster>(monster.StaticInfos.MainCreatureLightInfos.CreatureGenericId).NameId);
                    Console.WriteLine($@"(Monster) {monsterName} en cellid ->  {monster.Disposition.CellId}");
                    continue;
                }
                if (actor is GameRolePlayNpcInformations npc)
                {
                    Npcs.Add(npc.ContextualId, npc);
                    var npcName =
                        I18nDataManager.Instance.ReadText(ObjectDataManager.Instance.Get<Npc>((int)npc.NpcId).NameId);
                    Console.WriteLine($@"(Npc) {npcName} en cellid ->  {npc.Disposition.CellId}");
                    continue;
                }
                Others.Add(actor.ContextualId, actor);
                Console.WriteLine($@"(Other) Aucune Idée en cellid -> {actor.Disposition.CellId}");
            }
        }

        public void AddActor(GameRolePlayActorInformations actor)
        {
            if (actor is GameRolePlayCharacterInformations character && !Players.ContainsKey(actor.ContextualId))
            {
                Players.Add(character.ContextualId, character);
                Console.WriteLine($@"(Player) {character.Name} en cellid ->  {character.Disposition.CellId}");
                return;
            }
            if (actor is GameRolePlayGroupMonsterInformations monster && !Monsters.ContainsKey(actor.ContextualId))
            {
                Monsters.Add(monster.ContextualId, monster);
                var monsterName = I18nDataManager.Instance.ReadText(ObjectDataManager.Instance
                    .Get<Monster>(monster.StaticInfos.MainCreatureLightInfos.CreatureGenericId).NameId);
                Console.WriteLine($@"(Monster) {monsterName} en cellid ->  {monster.Disposition.CellId}");
                return;
            }
            if (actor is GameRolePlayNpcInformations npc && !Npcs.ContainsKey(actor.ContextualId))
            {
                Npcs.Add(npc.ContextualId, npc);
                var npcName =
                    I18nDataManager.Instance.ReadText(ObjectDataManager.Instance.Get<Npc>((int)npc.NpcId).NameId);
                Console.WriteLine($@"(Npc) {npcName} en cellid ->  {npc.Disposition.CellId}");
                return;
            }
            if (!Others.ContainsKey(actor.ContextualId))
                Others.Add(actor.ContextualId, actor);
        }

        public void RemoveActor(double contextualId)
        {
            if (Players.ContainsKey(contextualId))
                Players.Remove(contextualId);
            else if (Monsters.ContainsKey(contextualId))
                Monsters.Remove(contextualId);
            else if (Npcs.ContainsKey(contextualId))
                Npcs.Remove(contextualId);
            else if (Others.ContainsKey(contextualId))
                Others.Remove(contextualId);
        }

        public void RefreshActor(double contextualId, short cellEnd)
        {
            if (Players.ContainsKey(contextualId))
            {
                Players[contextualId].Disposition.CellId = cellEnd;
                Console.WriteLine($@"(Players) {Players[contextualId].Name} se déplace sur la cellid -> {cellEnd}");
            }
            else if (Monsters.ContainsKey(contextualId))
            {
                Monsters[contextualId].Disposition.CellId = cellEnd;
                Console.WriteLine($@"(Monsters) se déplace sur la cellid -> {cellEnd}");
            }
            else if (Others.ContainsKey(contextualId))
            {
                Others[contextualId].Disposition.CellId = cellEnd;
                Console.WriteLine($@"(Others) se déplace sur la cellid -> {cellEnd}");
            }
            else if (Npcs.ContainsKey(contextualId))
            {
                Npcs[contextualId].Disposition.CellId = cellEnd;
                Console.WriteLine($@"(Npcs) se déplace sur la cellid -> {cellEnd}");
            }
            else
                Console.WriteLine($@"Quelque chose se déplace sur la cellid -> {cellEnd}");
        }

        public void Clear()
        {
            Players.Clear();
            Monsters.Clear();
            Npcs.Clear();
            Others.Clear();
        }
    }
}