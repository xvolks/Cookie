using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ShortcutEmote : Shortcut
    {
        public new const ushort ProtocolId = 389;

        public override ushort TypeID => ProtocolId;

        public byte EmoteId { get; set; }
        public ShortcutEmote() { }

        public ShortcutEmote( byte EmoteId ){
            this.EmoteId = EmoteId;
        }

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
