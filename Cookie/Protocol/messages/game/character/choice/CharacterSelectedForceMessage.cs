using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterSelectedForceMessage : NetworkMessage
    {
        public const uint ProtocolId = 6068;
        public override uint MessageID { get { return ProtocolId; } }

        public int Id_ = 0;

        public CharacterSelectedForceMessage()
        {
        }

        public CharacterSelectedForceMessage(
            int id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadInt();
        }
    }
}