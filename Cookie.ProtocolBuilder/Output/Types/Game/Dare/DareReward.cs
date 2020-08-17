namespace Cookie.API.Protocol.Network.Types.Game.Dare
{
    using Utils.IO;

    public class DareReward : NetworkType
    {
        public const ushort ProtocolId = 505;
        public override ushort TypeID => ProtocolId;
        public byte Type { get; set; }
        public ushort MonsterId { get; set; }
        public ulong Kamas { get; set; }
        public double DareId { get; set; }

        public DareReward(byte type, ushort monsterId, ulong kamas, double dareId)
        {
            Type = type;
            MonsterId = monsterId;
            Kamas = kamas;
            DareId = dareId;
        }

        public DareReward() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Type);
            writer.WriteVarUhShort(MonsterId);
            writer.WriteVarUhLong(Kamas);
            writer.WriteDouble(DareId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadByte();
            MonsterId = reader.ReadVarUhShort();
            Kamas = reader.ReadVarUhLong();
            DareId = reader.ReadDouble();
        }

    }
}
