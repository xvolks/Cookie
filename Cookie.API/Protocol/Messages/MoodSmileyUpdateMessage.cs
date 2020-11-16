using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MoodSmileyUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6388;

        public override ushort MessageID => ProtocolId;

        public int AccountId { get; set; }
        public ulong PlayerId { get; set; }
        public ushort SmileyId { get; set; }
        public MoodSmileyUpdateMessage() { }

        public MoodSmileyUpdateMessage( int AccountId, ulong PlayerId, ushort SmileyId ){
            this.AccountId = AccountId;
            this.PlayerId = PlayerId;
            this.SmileyId = SmileyId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteVarUhShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
            PlayerId = reader.ReadVarUhLong();
            SmileyId = reader.ReadVarUhShort();
        }
    }
}
