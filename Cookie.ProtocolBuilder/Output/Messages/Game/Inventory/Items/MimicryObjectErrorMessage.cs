namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class MimicryObjectErrorMessage : SymbioticObjectErrorMessage
    {
        public new const ushort ProtocolId = 6461;
        public override ushort MessageID => ProtocolId;
        public bool Preview { get; set; }

        public MimicryObjectErrorMessage(bool preview)
        {
            Preview = preview;
        }

        public MimicryObjectErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Preview);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Preview = reader.ReadBoolean();
        }

    }
}
