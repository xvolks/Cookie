using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FriendDeleteRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5603;

        public override ushort MessageID => ProtocolId;

        public int AccountId { get; set; }
        public FriendDeleteRequestMessage() { }

        public FriendDeleteRequestMessage( int AccountId ){
            this.AccountId = AccountId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
        }
    }
}
