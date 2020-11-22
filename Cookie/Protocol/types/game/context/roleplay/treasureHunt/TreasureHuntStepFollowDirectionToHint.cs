using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TreasureHuntStepFollowDirectionToHint : TreasureHuntStep
    {
        public new const short ProtocolId = 472;
        public override short TypeId { get { return ProtocolId; } }

        public byte Direction = 1;
        public short NpcId = 0;

        public TreasureHuntStepFollowDirectionToHint(): base()
        {
        }

        public TreasureHuntStepFollowDirectionToHint(
            byte direction,
            short npcId
        ): base()
        {
            Direction = direction;
            NpcId = npcId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Direction);
            writer.WriteVarShort(NpcId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Direction = reader.ReadByte();
            NpcId = reader.ReadVarShort();
        }
    }
}