using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SpouseStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6265;
        public override uint MessageID { get { return ProtocolId; } }

        public bool HasSpouse = false;

        public SpouseStatusMessage()
        {
        }

        public SpouseStatusMessage(
            bool hasSpouse
        )
        {
            HasSpouse = hasSpouse;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(HasSpouse);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HasSpouse = reader.ReadBoolean();
        }
    }
}