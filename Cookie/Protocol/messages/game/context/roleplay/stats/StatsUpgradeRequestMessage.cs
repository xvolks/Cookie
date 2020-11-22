using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StatsUpgradeRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5610;
        public override uint MessageID { get { return ProtocolId; } }

        public bool UseAdditionnal = false;
        public byte StatId = 11;
        public short BoostPoint = 0;

        public StatsUpgradeRequestMessage()
        {
        }

        public StatsUpgradeRequestMessage(
            bool useAdditionnal,
            byte statId,
            short boostPoint
        )
        {
            UseAdditionnal = useAdditionnal;
            StatId = statId;
            BoostPoint = boostPoint;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(UseAdditionnal);
            writer.WriteByte(StatId);
            writer.WriteVarShort(BoostPoint);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            UseAdditionnal = reader.ReadBoolean();
            StatId = reader.ReadByte();
            BoostPoint = reader.ReadVarShort();
        }
    }
}