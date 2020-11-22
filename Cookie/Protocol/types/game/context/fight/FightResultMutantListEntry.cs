using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightResultMutantListEntry : FightResultFighterListEntry
    {
        public new const short ProtocolId = 216;
        public override short TypeId { get { return ProtocolId; } }

        public short Level = 0;

        public FightResultMutantListEntry(): base()
        {
        }

        public FightResultMutantListEntry(
            short outcome,
            byte wave,
            FightLoot rewards,
            double id_,
            bool alive,
            short level
        ): base(
            outcome,
            wave,
            rewards,
            id_,
            alive
        )
        {
            Level = level;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Level);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarShort();
        }
    }
}