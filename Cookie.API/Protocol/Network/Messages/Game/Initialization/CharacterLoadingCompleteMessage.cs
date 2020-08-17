namespace Cookie.API.Protocol.Network.Messages.Game.Initialization
{
    using Utils.IO;

    public class CharacterLoadingCompleteMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6471;
        public override ushort MessageID => ProtocolId;

        public CharacterLoadingCompleteMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
