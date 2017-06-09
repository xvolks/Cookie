using Cookie;
using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharacterSelectionMessage : NetworkMessage
    {
        public const uint ProtocolId = 152;
        public override uint MessageID { get { return ProtocolId; } }

        public ulong ID { get; set; }

        public CharacterSelectionMessage() { }

        public CharacterSelectionMessage(ulong id)
        {
            ID = id;
        }

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
