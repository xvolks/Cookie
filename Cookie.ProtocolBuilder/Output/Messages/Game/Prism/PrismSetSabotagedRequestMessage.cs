namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Utils.IO;

    public class PrismSetSabotagedRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6468;
        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }

        public PrismSetSabotagedRequestMessage(ushort subAreaId)
        {
            SubAreaId = subAreaId;
        }

        public PrismSetSabotagedRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
        }

    }
}
