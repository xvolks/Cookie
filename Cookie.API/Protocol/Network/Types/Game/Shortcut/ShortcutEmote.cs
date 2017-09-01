using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    public class ShortcutEmote : Shortcut
    {
        public new const ushort ProtocolId = 389;

        public ShortcutEmote(byte emoteId)
        {
            EmoteId = emoteId;
        }

        public ShortcutEmote()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte EmoteId { get; set; }

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