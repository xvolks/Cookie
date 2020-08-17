using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Creation
{
    public class CharacterCreationResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 161;

        public CharacterCreationResultMessage(byte result)
        {
            Result = result;
        }

        public CharacterCreationResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Result { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadByte();
        }
    }
}