using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    public class TitleLostMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6371;

        public TitleLostMessage(ushort titleId)
        {
            TitleId = titleId;
        }

        public TitleLostMessage()
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