using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Friend
{
    public class AbstractContactInformations : NetworkType
    {
        public const ushort ProtocolId = 380;

        public AbstractContactInformations(int accountId, string accountName)
        {
            AccountId = accountId;
            AccountName = accountName;
        }

        public AbstractContactInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int AccountId { get; set; }
        public string AccountName { get; set; }

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