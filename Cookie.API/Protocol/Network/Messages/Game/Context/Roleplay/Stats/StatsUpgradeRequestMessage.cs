using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Stats
{
    public class StatsUpgradeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5610;

        public StatsUpgradeRequestMessage(bool useAdditionnal, byte statId, ushort boostPoint)
        {
            UseAdditionnal = useAdditionnal;
            StatId = statId;
            BoostPoint = boostPoint;
        }

        public StatsUpgradeRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool UseAdditionnal { get; set; }
        public byte StatId { get; set; }
        public ushort BoostPoint { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(UseAdditionnal);
            writer.WriteByte(StatId);
            writer.WriteVarUhShort(BoostPoint);
        }

        public override void Deserialize(IDataReader reader)
        {
            UseAdditionnal = reader.ReadBoolean();
            StatId = reader.ReadByte();
            BoostPoint = reader.ReadVarUhShort();
        }
    }
}