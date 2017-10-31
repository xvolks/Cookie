namespace Cookie.API.Protocol.Network.Messages.Common.Basic
{
    using Utils.IO;

    public class BasicPongMessage : NetworkMessage
    {
        public const ushort ProtocolId = 183;
        public override ushort MessageID => ProtocolId;
        public bool Quiet { get; set; }

        public BasicPongMessage(bool quiet)
        {
            Quiet = quiet;
        }

        public BasicPongMessage() { }

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
