using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    public class TitleGainedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6364;

        public TitleGainedMessage(ushort titleId)
        {
            TitleId = titleId;
        }

        public TitleGainedMessage()
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