namespace Cookie.API.Protocol.Network.Messages.Common.Basic
{
    using Utils.IO;

    public class BasicPingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 182;
        public override ushort MessageID => ProtocolId;
        public bool Quiet { get; set; }

        public BasicPingMessage(bool quiet)
        {
            Quiet = quiet;
        }

        public BasicPingMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Quiet);
        }

        public override void Deserialize(IDataReader reader)
        {
            Quiet = reader.ReadBoolean();
        }

    }
}
