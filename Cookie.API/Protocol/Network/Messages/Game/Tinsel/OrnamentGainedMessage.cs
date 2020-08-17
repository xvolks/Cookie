using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    public class OrnamentGainedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6368;

        public OrnamentGainedMessage(short ornamentId)
        {
            OrnamentId = ornamentId;
        }

        public OrnamentGainedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public short OrnamentId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(OrnamentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            OrnamentId = reader.ReadShort();
        }
    }
}