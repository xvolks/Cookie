using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChatSmileyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 801;

        public override ushort MessageID => ProtocolId;

        public double EntityId { get; set; }
        public ushort SmileyId { get; set; }
        public int AccountId { get; set; }
        public ChatSmileyMessage() { }

        public ChatSmileyMessage( double EntityId, ushort SmileyId, int AccountId ){
            this.EntityId = EntityId;
            this.SmileyId = SmileyId;
            this.AccountId = AccountId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(EntityId);
            writer.WriteVarUhShort(SmileyId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            EntityId = reader.ReadDouble();
            SmileyId = reader.ReadVarUhShort();
            AccountId = reader.ReadInt();
        }
    }
}
