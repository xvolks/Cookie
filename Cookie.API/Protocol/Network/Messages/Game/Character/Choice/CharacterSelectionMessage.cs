using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharacterSelectionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 152;

        public CharacterSelectionMessage(ulong objectId)
        {
            ObjectId = objectId;
        }

        public CharacterSelectionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhLong();
        }
    }
}