using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AlmanachCalendarDateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6341;
        public override uint MessageID { get { return ProtocolId; } }

        public int Date = 0;

        public AlmanachCalendarDateMessage()
        {
        }

        public AlmanachCalendarDateMessage(
            int date
        )
        {
            Date = date;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(Date);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Date = reader.ReadInt();
        }
    }
}