using Cookie.API.Protocol.Network.Types.Game.Paddock;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildPaddockBoughtMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5952;

        public GuildPaddockBoughtMessage(PaddockContentInformations paddockInfo)
        {
            PaddockInfo = paddockInfo;
        }

        public GuildPaddockBoughtMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public PaddockContentInformations PaddockInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            PaddockInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockInfo = new PaddockContentInformations();
            PaddockInfo.Deserialize(reader);
        }
    }
}