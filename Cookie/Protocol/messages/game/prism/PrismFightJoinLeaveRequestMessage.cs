using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismFightJoinLeaveRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5843;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public bool Join = false;

        public PrismFightJoinLeaveRequestMessage()
        {
        }

        public PrismFightJoinLeaveRequestMessage(
            short subAreaId,
            bool join
        )
        {
            SubAreaId = subAreaId;
            Join = join;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteBoolean(Join);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            Join = reader.ReadBoolean();
        }
    }
}