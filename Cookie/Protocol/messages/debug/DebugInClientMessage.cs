using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DebugInClientMessage : NetworkMessage
    {
        public const uint ProtocolId = 6028;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Level = 0;
        public string Message;

        public DebugInClientMessage()
        {
        }

        public DebugInClientMessage(
            byte level,
            string message
        )
        {
            Level = level;
            Message = message;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Level);
            writer.WriteUTF(Message);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Level = reader.ReadByte();
            Message = reader.ReadUTF();
        }
    }
}