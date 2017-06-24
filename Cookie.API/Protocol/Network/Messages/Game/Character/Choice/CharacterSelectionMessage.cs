using Cookie.API.IO;

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

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhLong(ID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ID = reader.ReadVarUhLong();
        }
    }
}