namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class SymbioticObjectErrorMessage : ObjectErrorMessage
    {
        public new const ushort ProtocolId = 6526;
        public override ushort MessageID => ProtocolId;
        public sbyte ErrorCode { get; set; }

        public SymbioticObjectErrorMessage(sbyte errorCode)
        {
            ErrorCode = errorCode;
        }

        public SymbioticObjectErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(ErrorCode);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ErrorCode = reader.ReadSByte();
        }

    }
}
