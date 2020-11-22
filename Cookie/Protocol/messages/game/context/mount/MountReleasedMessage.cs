using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountReleasedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6308;
        public override uint MessageID { get { return ProtocolId; } }

        public int MountId = 0;

        public MountReleasedMessage()
        {
        }

        public MountReleasedMessage(
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