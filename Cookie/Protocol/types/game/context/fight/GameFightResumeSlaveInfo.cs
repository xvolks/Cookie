using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightResumeSlaveInfo : NetworkType
    {
        public const short ProtocolId = 364;
        public override short TypeId { get { return ProtocolId; } }

        public double SlaveId = 0;
        public List<GameFightSpellCooldown> SpellCooldowns;
        public byte SummonCount = 0;
        public byte BombCount = 0;

        public GameFightResumeSlaveInfo()
        {
        }

        public GameFightResumeSlaveInfo(
            double slaveId,
            List<GameFightSpellCooldown> spellCooldowns,
            byte summonCount,
            byte bombCount
        )
        {
            SlaveId = slaveId;
            SpellCooldowns = spellCooldowns;
            SummonCount = summonCount;
            BombCount = bombCount;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(SlaveId);
            writer.WriteShort((short)SpellCooldowns.Count());
            foreach (var current in SpellCooldowns)
            {
                current.Serialize(writer);
            }
            writer.WriteByte(SummonCount);
            writer.WriteByte(BombCount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SlaveId = reader.ReadDouble();
            var countSpellCooldowns = reader.ReadShort();
            SpellCooldowns = new List<GameFightSpellCooldown>();
            for (short i = 0; i < countSpellCooldowns; i++)
            {
                GameFightSpellCooldown type = new GameFightSpellCooldown();
                type.Deserialize(reader);
                SpellCooldowns.Add(type);
            }
            SummonCount = reader.ReadByte();
            BombCount = reader.ReadByte();
        }
    }
}