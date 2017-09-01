namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    using Utils.IO;

    public class CharacterSelectedErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5836;
        public override ushort MessageID => ProtocolId;

        public CharacterSelectedErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
