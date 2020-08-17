namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Messages.Game.Inventory;
    using Utils.IO;

    public class IdolsPresetSaveResultMessage : AbstractPresetSaveResultMessage
    {
        public new const ushort ProtocolId = 6604;
        public override ushort MessageID => ProtocolId;

        public IdolsPresetSaveResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
