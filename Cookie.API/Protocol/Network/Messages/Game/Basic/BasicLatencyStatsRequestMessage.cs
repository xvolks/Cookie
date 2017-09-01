using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class BasicLatencyStatsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5816;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}