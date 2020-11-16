using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChatServerMessage : ChatAbstractServerMessage
    {
        public new const ushort ProtocolId = 881;

        public override ushort MessageID => ProtocolId;

        public double SenderId { get; set; }
        public string SenderName { get; set; }
        public string Prefix { get; set; }
        public int SenderAccountId { get; set; }
        public ChatServerMessage() { }

        public ChatServerMessage( double SenderId, string SenderName, string Prefix, int SenderAccountId ){
            this.SenderId = SenderId;
            this.SenderName = SenderName;
            this.Prefix = Prefix;
            this.SenderAccountId = SenderAccountId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(SenderId);
            writer.WriteUTF(SenderName);
            writer.WriteUTF(Prefix);
            writer.WriteInt(SenderAccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SenderId = reader.ReadDouble();
            SenderName = reader.ReadUTF();
            Prefix = reader.ReadUTF();
            SenderAccountId = reader.ReadInt();
        }
    }
}
