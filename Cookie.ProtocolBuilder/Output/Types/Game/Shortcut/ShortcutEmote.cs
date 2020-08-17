namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutEmote : Shortcut
    {
        public new const ushort ProtocolId = 389;
        public override ushort TypeID => ProtocolId;
        public byte EmoteId { get; set; }

        public ShortcutEmote(byte emoteId)
        {
            EmoteId = emoteId;
        }

        public ShortcutEmote() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(EmoteId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EmoteId = reader.ReadByte();
        }

    }
}
