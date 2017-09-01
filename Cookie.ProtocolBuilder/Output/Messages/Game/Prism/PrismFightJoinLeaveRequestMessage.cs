namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Utils.IO;

    public class PrismFightJoinLeaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5843;
        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public bool Join { get; set; }

        public PrismFightJoinLeaveRequestMessage(ushort subAreaId, bool join)
        {
            SubAreaId = subAreaId;
            Join = join;
        }

        public PrismFightJoinLeaveRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteBoolean(Join);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            Join = reader.ReadBoolean();
        }

    }
}
