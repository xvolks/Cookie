namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Types.Game.Guild.Tax;
    using System.Collections.Generic;
    using Utils.IO;

    public class TopTaxCollectorListMessage : AbstractTaxCollectorListMessage
    {
        public new const ushort ProtocolId = 6565;
        public override ushort MessageID => ProtocolId;
        public bool IsDungeon { get; set; }

        public TopTaxCollectorListMessage(bool isDungeon)
        {
            IsDungeon = isDungeon;
        }

        public TopTaxCollectorListMessage() { }

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
