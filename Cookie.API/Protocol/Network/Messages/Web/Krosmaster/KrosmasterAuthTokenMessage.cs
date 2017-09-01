using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    public class KrosmasterAuthTokenMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6351;

        public KrosmasterAuthTokenMessage(string token)
        {
            Token = token;
        }

        public KrosmasterAuthTokenMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Token { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Token);
        }

        public override void Deserialize(IDataReader reader)
        {
            Token = reader.ReadUTF();
        }
    }
}