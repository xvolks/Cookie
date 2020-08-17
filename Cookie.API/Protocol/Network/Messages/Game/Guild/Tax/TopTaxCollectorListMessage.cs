using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class TopTaxCollectorListMessage : AbstractTaxCollectorListMessage
    {
        public new const ushort ProtocolId = 6565;

        public TopTaxCollectorListMessage(bool isDungeon)
        {
            IsDungeon = isDungeon;
        }

        public TopTaxCollectorListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool IsDungeon { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(IsDungeon);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            IsDungeon = reader.ReadBoolean();
        }
    }
}