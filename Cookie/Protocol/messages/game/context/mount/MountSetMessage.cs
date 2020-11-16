using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountSetMessage : NetworkMessage
    {
        public const uint ProtocolId = 5968;
        public override uint MessageID { get { return ProtocolId; } }

        public MountClientData MountData;

        public MountSetMessage()
        {
        }

        public MountSetMessage(
            MountClientData mountData
        )
        {
            MountData = mountData;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            MountData.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MountData = new MountClientData();
            MountData.Deserialize(reader);
        }
    }
}