using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ShortcutEmote : Shortcut
    {
        public new const short ProtocolId = 389;
        public override short TypeId { get { return ProtocolId; } }

        public byte EmoteId = 0;

        public ShortcutEmote(): base()
        {
        }

        public ShortcutEmote(
            byte slot,
            byte emoteId
        ): base(
            slot
        )
        {
            EmoteId = emoteId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(EmoteId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            EmoteId = reader.ReadByte();
        }
    }
}