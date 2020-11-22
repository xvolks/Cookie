using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IgnoredDeleteRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5680;

        public override ushort MessageID => ProtocolId;

        public int AccountId { get; set; }
        public bool Session { get; set; }
        public IgnoredDeleteRequestMessage() { }

        public IgnoredDeleteRequestMessage( int AccountId, bool Session ){
            this.AccountId = AccountId;
            this.Session = Session;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
            Session = reader.ReadBoolean();
        }
    }
}
