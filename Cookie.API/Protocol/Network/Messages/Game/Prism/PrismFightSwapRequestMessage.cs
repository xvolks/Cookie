using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismFightSwapRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5901;

        public PrismFightSwapRequestMessage(ushort subAreaId, ulong targetId)
        {
            SubAreaId = subAreaId;
            TargetId = targetId;
        }

        public PrismFightSwapRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public ulong TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhLong(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            TargetId = reader.ReadVarUhLong();
        }
    }
}