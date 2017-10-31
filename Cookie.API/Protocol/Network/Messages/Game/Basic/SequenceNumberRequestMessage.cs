namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class SequenceNumberRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6316;
        public override ushort MessageID => ProtocolId;

        public SequenceNumberRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
