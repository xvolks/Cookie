using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NotificationUpdateFlagMessage : NetworkMessage
    {
        public const uint ProtocolId = 6090;
        public override uint MessageID { get { return ProtocolId; } }

        public short Index = 0;

        public NotificationUpdateFlagMessage()
        {
        }

        public NotificationUpdateFlagMessage(
            short index
        )
        {
            Index = index;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Index);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Index = reader.ReadVarShort();
        }
    }
}