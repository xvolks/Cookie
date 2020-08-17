using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    public class TitleSelectedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6366;

        public TitleSelectedMessage(ushort titleId)
        {
            TitleId = titleId;
        }

        public TitleSelectedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort TitleId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(TitleId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TitleId = reader.ReadVarUhShort();
        }
    }
}