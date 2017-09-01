namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Utils.IO;

    public class PrismSettingsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6437;
        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public byte StartDefenseTime { get; set; }

        public PrismSettingsRequestMessage(ushort subAreaId, byte startDefenseTime)
        {
            SubAreaId = subAreaId;
            StartDefenseTime = startDefenseTime;
        }

        public PrismSettingsRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteByte(StartDefenseTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            StartDefenseTime = reader.ReadByte();
        }

    }
}
