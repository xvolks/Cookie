namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Utils.IO;

    public class PrismInfoCloseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5853;
        public override ushort MessageID => ProtocolId;

        public PrismInfoCloseMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
