using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    public class OrnamentSelectedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6369;

        public OrnamentSelectedMessage(ushort ornamentId)
        {
            OrnamentId = ornamentId;
        }

        public OrnamentSelectedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort OrnamentId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(OrnamentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            OrnamentId = reader.ReadVarUhShort();
        }
    }
}