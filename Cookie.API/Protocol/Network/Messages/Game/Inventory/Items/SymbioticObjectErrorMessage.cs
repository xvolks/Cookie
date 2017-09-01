using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class SymbioticObjectErrorMessage : ObjectErrorMessage
    {
        public new const ushort ProtocolId = 6526;

        public SymbioticObjectErrorMessage(sbyte errorCode)
        {
            ErrorCode = errorCode;
        }

        public SymbioticObjectErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte ErrorCode { get; set; }

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