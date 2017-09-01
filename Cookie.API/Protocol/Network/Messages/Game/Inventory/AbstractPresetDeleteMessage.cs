using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory
{
    public class AbstractPresetDeleteMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6735;

        public AbstractPresetDeleteMessage(byte presetId)
        {
            PresetId = presetId;
        }

        public AbstractPresetDeleteMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
        }
    }
}