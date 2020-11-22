using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapComplementaryInformationsAnomalyMessage : MapComplementaryInformationsDataMessage
    {
        public new const ushort ProtocolId = 6828;

        public override ushort MessageID => ProtocolId;

        public ushort Level { get; set; }
        public ulong ClosingTime { get; set; }
        public MapComplementaryInformationsAnomalyMessage() { }

        public MapComplementaryInformationsAnomalyMessage( ushort Level, ulong ClosingTime ){
            this.Level = Level;
            this.ClosingTime = ClosingTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Level);
            writer.WriteVarUhLong(ClosingTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUhShort();
            ClosingTime = reader.ReadVarUhLong();
        }
    }
}
