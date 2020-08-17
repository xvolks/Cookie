using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Debug
{
    public class DebugClearHighlightCellsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 2002;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}