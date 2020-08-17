using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class TeleportOnSameMapMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6048;

        public TeleportOnSameMapMessage(double targetId, ushort cellId)
        {
            TargetId = targetId;
            CellId = cellId;
        }

        public TeleportOnSameMapMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public ushort CellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(TargetId);
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadDouble();
            CellId = reader.ReadVarUhShort();
        }
    }
}