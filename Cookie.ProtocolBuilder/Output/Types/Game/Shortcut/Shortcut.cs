namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    using Utils.IO;

    public class Shortcut : NetworkType
    {
        public const ushort ProtocolId = 369;
        public override ushort TypeID => ProtocolId;
        public byte Slot { get; set; }

        public Shortcut(byte slot)
        {
            Slot = slot;
        }

        public Shortcut() { }

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
