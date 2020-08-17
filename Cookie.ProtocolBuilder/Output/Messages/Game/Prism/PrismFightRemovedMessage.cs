namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Utils.IO;

    public class PrismFightRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6453;
        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }

        public PrismFightRemovedMessage(ushort subAreaId)
        {
            SubAreaId = subAreaId;
        }

        public PrismFightRemovedMessage() { }

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
