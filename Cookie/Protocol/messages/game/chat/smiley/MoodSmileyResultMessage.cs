using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MoodSmileyResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 6196;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ResultCode = 1;
        public short SmileyId = 0;

        public MoodSmileyResultMessage()
        {
        }

        public MoodSmileyResultMessage(
            byte resultCode,
            short smileyId
        )
        {
            ResultCode = resultCode;
            SmileyId = smileyId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(ResultCode);
            writer.WriteVarShort(SmileyId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ResultCode = reader.ReadByte();
            SmileyId = reader.ReadVarShort();
        }
    }
}