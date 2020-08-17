using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismSetSabotagedRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6466;

        public PrismSetSabotagedRefusedMessage(ushort subAreaId, sbyte reason)
        {
            SubAreaId = subAreaId;
            Reason = reason;
        }

        public PrismSetSabotagedRefusedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public sbyte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            Reason = reader.ReadSByte();
        }
    }
}