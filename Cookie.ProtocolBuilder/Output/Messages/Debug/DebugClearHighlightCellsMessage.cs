namespace Cookie.API.Protocol.Network.Messages.Debug
{
    using Utils.IO;

    public class DebugClearHighlightCellsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 2002;
        public override ushort MessageID => ProtocolId;

        public DebugClearHighlightCellsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
