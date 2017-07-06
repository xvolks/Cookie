using System;
using System.Collections.Generic;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Gamedata;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;

namespace Cookie.Game.Fight.Fighters
{
    public class Companion : Fighter, ICompanion
    {
        public Companion(double id, int cellId, GameFightMinimalStats stats, uint teamId, bool isAlive,
    byte companionGenericId, int level, double masterId) : base(id, cellId, stats, teamId, isAlive)
        {
            Level = level;
            CompanionGenericId = companionGenericId;
            MasterId = MasterId;
            Name = (string)D2OParsing.GetMonsterName((int)CompanionGenericId);
        }
        public string Name { get; internal set; }
        public int Level { get; internal set; }
        public byte CompanionGenericId { get; internal set; }
        public double MasterId { get; internal set; }
    }
}
