using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightTurnStartPlayingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6465;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}