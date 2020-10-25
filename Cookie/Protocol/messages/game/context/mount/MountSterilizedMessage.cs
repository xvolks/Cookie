using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountSterilizedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5977;
        public override uint MessageID { get { return ProtocolId; } }

        public int MountId = 0;

        public MountSterilizedMessage()
        {
        }

        public MountSterilizedMessage(
            int mountId
        )
        {
            MountId = mountId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(MountId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MountId = reader.ReadVarInt();
        }
    }
}