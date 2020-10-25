using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IgnoredDeleteResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 5677;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Success = false;
        public bool Session = false;
        public string Name;

        public IgnoredDeleteResultMessage()
        {
        }

        public IgnoredDeleteResultMessage(
            bool success,
            bool session,
            string name
        )
        {
            Success = success;
            Session = session;
            Name = name;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Success);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, Session);
            writer.WriteByte(box0);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(box0, 1);
            Session = BooleanByteWrapper.GetFlag(box0, 2);
            Name = reader.ReadUTF();
        }
    }
}