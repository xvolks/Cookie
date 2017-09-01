namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class BasicWhoAmIRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5664;
        public override ushort MessageID => ProtocolId;
        public bool Verbose { get; set; }

        public BasicWhoAmIRequestMessage(bool verbose)
        {
            Verbose = verbose;
        }

        public BasicWhoAmIRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Verbose);
        }

        public override void Deserialize(IDataReader reader)
        {
            Verbose = reader.ReadBoolean();
        }

    }
}
