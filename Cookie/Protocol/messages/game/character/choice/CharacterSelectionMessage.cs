using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterSelectionMessage : NetworkMessage
    {
        public const uint ProtocolId = 152;
        public override uint MessageID { get { return ProtocolId; } }

        public long Id_ = 0;

        public CharacterSelectionMessage()
        {
        }

        public CharacterSelectionMessage(
            long id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarLong();
        }
    }
}