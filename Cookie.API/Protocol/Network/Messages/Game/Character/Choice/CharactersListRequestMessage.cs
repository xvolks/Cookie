namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    using Utils.IO;

    public class CharactersListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 150;
        public override ushort MessageID => ProtocolId;

        public CharactersListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
