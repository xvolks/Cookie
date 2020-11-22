using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StatsUpgradeResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 5609;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Result = 0;
        public short NbCharacBoost = 0;

        public StatsUpgradeResultMessage()
        {
        }

        public StatsUpgradeResultMessage(
            byte result,
            short nbCharacBoost
        )
        {
            Result = result;
            NbCharacBoost = nbCharacBoost;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Result);
            writer.WriteVarShort(NbCharacBoost);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Result = reader.ReadByte();
            NbCharacBoost = reader.ReadVarShort();
        }
    }
}