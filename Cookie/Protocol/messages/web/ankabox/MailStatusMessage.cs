using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MailStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6275;
        public override uint MessageID { get { return ProtocolId; } }

        public short Unread = 0;
        public short Total = 0;

        public MailStatusMessage()
        {
        }

        public MailStatusMessage(
            short unread,
            short total
        )
        {
            Unread = unread;
            Total = total;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Unread);
            writer.WriteVarShort(Total);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Unread = reader.ReadVarShort();
            Total = reader.ReadVarShort();
        }
    }
}