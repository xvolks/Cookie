using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AbstractContactInformations : NetworkType
    {
        public const ushort ProtocolId = 380;

        public override ushort TypeID => ProtocolId;

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public AbstractContactInformations() { }

        public AbstractContactInformations( int AccountId, string AccountName ){
            this.AccountId = AccountId;
            this.AccountName = AccountName;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteUTF(AccountName);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
            AccountName = reader.ReadUTF();
        }
    }
}
