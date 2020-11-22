using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AccountLoggingKickedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6029;
        public override uint MessageID { get { return ProtocolId; } }

        public short Days = 0;
        public byte Hours = 0;
        public byte Minutes = 0;

        public AccountLoggingKickedMessage()
        {
        }

        public AccountLoggingKickedMessage(
            short days,
            byte hours,
            byte minutes
        )
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Days);
            writer.WriteByte(Hours);
            writer.WriteByte(Minutes);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Days = reader.ReadVarShort();
            Hours = reader.ReadByte();
            Minutes = reader.ReadByte();
        }
    }
}