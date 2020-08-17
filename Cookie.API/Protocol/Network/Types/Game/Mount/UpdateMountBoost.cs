using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Mount
{
    public class UpdateMountBoost : NetworkType
    {
        public const ushort ProtocolId = 356;

        public UpdateMountBoost(byte type)
        {
            Type = type;
        }

        public UpdateMountBoost()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Type { get; set; }

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