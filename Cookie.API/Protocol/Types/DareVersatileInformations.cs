using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class DareVersatileInformations : NetworkType
    {
        public const ushort ProtocolId = 504;

        public override ushort TypeID => ProtocolId;

        public double DareId { get; set; }
        public int CountEntrants { get; set; }
        public int CountWinners { get; set; }
        public DareVersatileInformations() { }

        public DareVersatileInformations( double DareId, int CountEntrants, int CountWinners ){
            this.DareId = DareId;
            this.CountEntrants = CountEntrants;
            this.CountWinners = CountWinners;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteInt(CountEntrants);
            writer.WriteInt(CountWinners);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            CountEntrants = reader.ReadInt();
            CountWinners = reader.ReadInt();
        }
    }
}
