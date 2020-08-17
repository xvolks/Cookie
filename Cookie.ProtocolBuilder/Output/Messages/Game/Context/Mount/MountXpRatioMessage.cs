namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountXpRatioMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5970;
        public override ushort MessageID => ProtocolId;
        public byte Ratio { get; set; }

        public MountXpRatioMessage(byte ratio)
        {
            Ratio = ratio;
        }

        public MountXpRatioMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Ratio);
        }

        public override void Deserialize(IDataReader reader)
        {
            Ratio = reader.ReadByte();
        }

    }
}
