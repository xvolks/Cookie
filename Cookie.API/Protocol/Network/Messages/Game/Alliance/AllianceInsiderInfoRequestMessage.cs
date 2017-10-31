namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Utils.IO;

    public class AllianceInsiderInfoRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6417;
        public override ushort MessageID => ProtocolId;

        public AllianceInsiderInfoRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
