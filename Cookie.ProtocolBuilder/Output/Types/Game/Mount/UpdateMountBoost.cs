namespace Cookie.API.Protocol.Network.Types.Game.Mount
{
    using Utils.IO;

    public class UpdateMountBoost : NetworkType
    {
        public const ushort ProtocolId = 356;
        public override ushort TypeID => ProtocolId;
        public byte Type { get; set; }

        public UpdateMountBoost(byte type)
        {
            Type = type;
        }

        public UpdateMountBoost() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadByte();
        }

    }
}
