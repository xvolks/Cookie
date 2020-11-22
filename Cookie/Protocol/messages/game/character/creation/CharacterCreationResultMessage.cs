using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterCreationResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 161;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Result = 1;

        public CharacterCreationResultMessage()
        {
        }

        public CharacterCreationResultMessage(
            byte result
        )
        {
            Result = result;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Result);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Result = reader.ReadByte();
        }
    }
}