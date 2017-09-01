using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    public class Shortcut : NetworkType
    {
        public const ushort ProtocolId = 369;

        public Shortcut(byte slot)
        {
            Slot = slot;
        }

        public Shortcut()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Slot { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Slot);
        }

        public override void Deserialize(IDataReader reader)
        {
            Slot = reader.ReadByte();
        }
    }
}