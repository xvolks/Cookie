using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareCreatedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6668;
        public override uint MessageID { get { return ProtocolId; } }

        public DareInformations DareInfos;
        public bool NeedNotifications = false;

        public DareCreatedMessage()
        {
        }

        public DareCreatedMessage(
            DareInformations dareInfos,
            bool needNotifications
        )
        {
            DareInfos = dareInfos;
            NeedNotifications = needNotifications;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            DareInfos.Serialize(writer);
            writer.WriteBoolean(NeedNotifications);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DareInfos = new DareInformations();
            DareInfos.Deserialize(reader);
            NeedNotifications = reader.ReadBoolean();
        }
    }
}