namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class GameContextCreateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 200;
        public override ushort MessageID => ProtocolId;
        public byte Context { get; set; }

        public GameContextCreateMessage(byte context)
        {
            Context = context;
        }

        public GameContextCreateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Context);
        }

        public override void Deserialize(IDataReader reader)
        {
            Context = reader.ReadByte();
        }

    }
}
