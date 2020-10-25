using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IgnoredAddRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5673;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;
        public bool Session = false;

        public IgnoredAddRequestMessage()
        {
        }

        public IgnoredAddRequestMessage(
            string name,
            bool session
        )
        {
            Name = name;
            Session = session;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Name);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Name = reader.ReadUTF();
            Session = reader.ReadBoolean();
        }
    }
}