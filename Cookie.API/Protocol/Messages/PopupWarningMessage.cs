using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PopupWarningMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6134;

        public override ushort MessageID => ProtocolId;

        public byte LockDuration { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public PopupWarningMessage() { }

        public PopupWarningMessage( byte LockDuration, string Author, string Content ){
            this.LockDuration = LockDuration;
            this.Author = Author;
            this.Content = Content;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(LockDuration);
            writer.WriteUTF(Author);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            LockDuration = reader.ReadByte();
            Author = reader.ReadUTF();
            Content = reader.ReadUTF();
        }
    }
}
