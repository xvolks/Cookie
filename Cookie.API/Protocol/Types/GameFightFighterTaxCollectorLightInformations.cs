using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightFighterTaxCollectorLightInformations : GameFightFighterLightInformations
    {
        public new const ushort ProtocolId = 457;

        public override ushort TypeID => ProtocolId;

        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public GameFightFighterTaxCollectorLightInformations() { }

        public GameFightFighterTaxCollectorLightInformations( ushort FirstNameId, ushort LastNameId ){
            this.FirstNameId = FirstNameId;
            this.LastNameId = LastNameId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
        }
    }
}
