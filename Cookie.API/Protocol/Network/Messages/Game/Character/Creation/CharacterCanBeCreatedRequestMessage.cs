namespace Cookie.API.Protocol.Network.Messages.Game.Character.Creation
{
    using Utils.IO;

    public class CharacterCanBeCreatedRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6732;
        public override ushort MessageID => ProtocolId;

        public CharacterCanBeCreatedRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
