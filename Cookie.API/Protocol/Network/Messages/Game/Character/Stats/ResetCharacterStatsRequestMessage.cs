using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    public class ResetCharacterStatsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6739;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}