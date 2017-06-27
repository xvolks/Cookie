using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharacterSelectionMessage : NetworkMessage
    {
        public const uint ProtocolId = 152;

        public CharacterSelectionMessage()
        {
        }

        public CharacterSelectionMessage(ulong id)
        {
            ID = id;
        }

        public override uint MessageID => ProtocolId;

        public ulong ID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ID = reader.ReadVarUhLong();
        }
    }
}