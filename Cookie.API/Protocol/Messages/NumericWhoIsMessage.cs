using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class NumericWhoIsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6297;

        public override ushort MessageID => ProtocolId;

        public ulong PlayerId { get; set; }
        public int AccountId { get; set; }
        public NumericWhoIsMessage() { }

        public NumericWhoIsMessage( ulong PlayerId, int AccountId ){
            this.PlayerId = PlayerId;
            this.AccountId = AccountId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
            AccountId = reader.ReadInt();
        }
    }
}
