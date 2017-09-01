namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Preset
{
    using Messages.Game.Inventory;
    using Utils.IO;

    public class IdolsPresetDeleteMessage : AbstractPresetDeleteMessage
    {
        public new const ushort ProtocolId = 6602;
        public override ushort MessageID => ProtocolId;

        public IdolsPresetDeleteMessage() { }

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
