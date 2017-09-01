namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountDataErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6172;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public MountDataErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public MountDataErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }

    }
}
