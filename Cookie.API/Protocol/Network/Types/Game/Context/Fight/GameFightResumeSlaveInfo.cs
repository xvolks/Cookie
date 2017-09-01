using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class GameFightResumeSlaveInfo : NetworkType
    {
        public const ushort ProtocolId = 364;

        public GameFightResumeSlaveInfo(double slaveId, List<GameFightSpellCooldown> spellCooldowns, byte summonCount,
            byte bombCount)
        {
            SlaveId = slaveId;
            SpellCooldowns = spellCooldowns;
            SummonCount = summonCount;
            BombCount = bombCount;
        }

        public GameFightResumeSlaveInfo()
        {
        }

        public override ushort TypeID => ProtocolId;
        public double SlaveId { get; set; }
        public List<GameFightSpellCooldown> SpellCooldowns { get; set; }
        public byte SummonCount { get; set; }
        public byte BombCount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(SlaveId);
            writer.WriteShort((short) SpellCooldowns.Count);
            for (var spellCooldownsIndex = 0; spellCooldownsIndex < SpellCooldowns.Count; spellCooldownsIndex++)
            {
                var objectToSend = SpellCooldowns[spellCooldownsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteByte(SummonCount);
            writer.WriteByte(BombCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            SlaveId = reader.ReadDouble();
            var spellCooldownsCount = reader.ReadUShort();
            SpellCooldowns = new List<GameFightSpellCooldown>();
            for (var spellCooldownsIndex = 0; spellCooldownsIndex < spellCooldownsCount; spellCooldownsIndex++)
            {
                var objectToAdd = new GameFightSpellCooldown();
                objectToAdd.Deserialize(reader);
                SpellCooldowns.Add(objectToAdd);
            }
            SummonCount = reader.ReadByte();
            BombCount = reader.ReadByte();
        }
    }
}