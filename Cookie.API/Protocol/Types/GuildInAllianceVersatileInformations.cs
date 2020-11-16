using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GuildInAllianceVersatileInformations : GuildVersatileInformations
    {
        public new const ushort ProtocolId = 437;

        public override ushort TypeID => ProtocolId;

        public uint AllianceId { get; set; }
        public GuildInAllianceVersatileInformations() { }

        public GuildInAllianceVersatileInformations( uint AllianceId ){
            this.AllianceId = AllianceId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(AllianceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceId = reader.ReadVarUhInt();
        }
    }
}
