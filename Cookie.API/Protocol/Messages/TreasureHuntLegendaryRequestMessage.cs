using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntLegendaryRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6499;

        public override ushort MessageID => ProtocolId;

        public ushort LegendaryId { get; set; }
        public TreasureHuntLegendaryRequestMessage() { }

        public TreasureHuntLegendaryRequestMessage( ushort LegendaryId ){
            this.LegendaryId = LegendaryId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(LegendaryId);
        }

        public override void Deserialize(IDataReader reader)
        {
            LegendaryId = reader.ReadVarUhShort();
        }
    }
}
