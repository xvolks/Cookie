using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    public class TitlesAndOrnamentsListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6363;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}