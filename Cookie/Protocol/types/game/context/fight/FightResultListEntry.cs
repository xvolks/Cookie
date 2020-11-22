using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightResultListEntry : NetworkType
    {
        public const short ProtocolId = 16;
        public override short TypeId { get { return ProtocolId; } }

        public short Outcome = 0;
        public byte Wave = 0;
        public FightLoot Rewards;

        public FightResultListEntry()
        {
        }

        public FightResultListEntry(
            short outcome,
            byte wave,
            FightLoot rewards
        )
        {
            Outcome = outcome;
            Wave = wave;
            Rewards = rewards;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Outcome);
            writer.WriteByte(Wave);
            Rewards.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Outcome = reader.ReadVarShort();
            Wave = reader.ReadByte();
            Rewards = new FightLoot();
            Rewards.Deserialize(reader);
        }
    }
}