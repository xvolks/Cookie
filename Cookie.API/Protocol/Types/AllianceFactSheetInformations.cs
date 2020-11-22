using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AllianceFactSheetInformations : AllianceInformations
    {
        public new const ushort ProtocolId = 421;

        public override ushort TypeID => ProtocolId;

        public int CreationDate { get; set; }
        public AllianceFactSheetInformations() { }

        public AllianceFactSheetInformations( int CreationDate ){
            this.CreationDate = CreationDate;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(CreationDate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CreationDate = reader.ReadInt();
        }
    }
}
