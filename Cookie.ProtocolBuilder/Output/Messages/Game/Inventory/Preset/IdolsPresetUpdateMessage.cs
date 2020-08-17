namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Types.Game.Inventory.Preset;
    using Utils.IO;

    public class IdolsPresetUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6606;
        public override ushort MessageID => ProtocolId;
        public IdolsPreset IdolsPreset { get; set; }

        public IdolsPresetUpdateMessage(IdolsPreset idolsPreset)
        {
            IdolsPreset = idolsPreset;
        }

        public IdolsPresetUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            IdolsPreset.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            IdolsPreset = new IdolsPreset();
            IdolsPreset.Deserialize(reader);
        }

    }
}
