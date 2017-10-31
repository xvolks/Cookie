namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Utils.IO;

    public class IdolsPresetDeleteResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6605;
        public override ushort MessageID => ProtocolId;
        public byte PresetId { get; set; }
        public byte Code { get; set; }

        public IdolsPresetDeleteResultMessage(byte presetId, byte code)
        {
            PresetId = presetId;
            Code = code;
        }

        public IdolsPresetDeleteResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteByte(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            Code = reader.ReadByte();
        }

    }
}
