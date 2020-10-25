using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AbstractContactInformations : NetworkType
    {
        public const short ProtocolId = 380;
        public override short TypeId { get { return ProtocolId; } }

        public int AccountId = 0;
        public string AccountName;

        public AbstractContactInformations()
        {
        }

        public AbstractContactInformations(
            int accountId,
            string accountName
        )
        {
            AccountId = accountId;
            AccountName = accountName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteUTF(AccountName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AccountId = reader.ReadInt();
            AccountName = reader.ReadUTF();
        }
    }
}