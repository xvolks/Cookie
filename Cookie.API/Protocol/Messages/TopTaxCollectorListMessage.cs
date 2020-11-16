using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TopTaxCollectorListMessage : AbstractTaxCollectorListMessage
    {
        public new const ushort ProtocolId = 6565;

        public override ushort MessageID => ProtocolId;

        public bool IsDungeon { get; set; }
        public TopTaxCollectorListMessage() { }

        public TopTaxCollectorListMessage( bool IsDungeon ){
            this.IsDungeon = IsDungeon;
        }

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
