namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Utils.IO;

    public class PrismAttackRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6042;
        public override ushort MessageID => ProtocolId;

        public PrismAttackRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
