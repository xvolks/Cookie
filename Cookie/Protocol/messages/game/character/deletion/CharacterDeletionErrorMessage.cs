using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterDeletionErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 166;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 1;

        public CharacterDeletionErrorMessage()
        {
        }

        public CharacterDeletionErrorMessage(
            byte reason
        )
        {
            Reason = reason;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Reason = reader.ReadByte();
        }
    }
}