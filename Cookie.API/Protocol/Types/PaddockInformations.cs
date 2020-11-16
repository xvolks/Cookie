using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PaddockInformations : NetworkType
    {
        public const ushort ProtocolId = 132;

        public override ushort TypeID => ProtocolId;

        public ushort MaxOutdoorMount { get; set; }
        public ushort MaxItems { get; set; }
        public PaddockInformations() { }

        public PaddockInformations( ushort MaxOutdoorMount, ushort MaxItems ){
            this.MaxOutdoorMount = MaxOutdoorMount;
            this.MaxItems = MaxItems;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(MaxOutdoorMount);
            writer.WriteVarUhShort(MaxItems);
        }

        public override void Deserialize(IDataReader reader)
        {
            MaxOutdoorMount = reader.ReadVarUhShort();
            MaxItems = reader.ReadVarUhShort();
        }
    }
}
