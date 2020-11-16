using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightResultFighterListEntry : FightResultListEntry
    {
        public new const short ProtocolId = 189;
        public override short TypeId { get { return ProtocolId; } }

        public double Id_ = 0;
        public bool Alive = false;

        public FightResultFighterListEntry(): base()
        {
        }

        public FightResultFighterListEntry(
            short outcome,
            byte wave,
            FightLoot rewards,
            double id_,
            bool alive
        ): base(
            outcome,
            wave,
            rewards
        )
        {
            Id_ = id_;
            Alive = alive;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(Id_);
            writer.WriteBoolean(Alive);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Id_ = reader.ReadDouble();
            Alive = reader.ReadBoolean();
        }
    }
}