using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismSettingsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6437;

        public PrismSettingsRequestMessage(ushort subAreaId, byte startDefenseTime)
        {
            SubAreaId = subAreaId;
            StartDefenseTime = startDefenseTime;
        }

        public PrismSettingsRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public byte StartDefenseTime { get; set; }

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