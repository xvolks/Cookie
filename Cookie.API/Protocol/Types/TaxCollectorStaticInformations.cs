using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TaxCollectorStaticInformations : NetworkType
    {
        public const ushort ProtocolId = 147;

        public override ushort TypeID => ProtocolId;

        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public GuildInformations GuildIdentity { get; set; }
        public TaxCollectorStaticInformations() { }

        public TaxCollectorStaticInformations( ushort FirstNameId, ushort LastNameId, GuildInformations GuildIdentity ){
            this.FirstNameId = FirstNameId;
            this.LastNameId = LastNameId;
            this.GuildIdentity = GuildIdentity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
            GuildIdentity.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            GuildIdentity = new GuildInformations();
            GuildIdentity.Deserialize(reader);
        }
    }
}
