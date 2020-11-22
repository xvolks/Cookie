using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightResultMutantListEntry : FightResultFighterListEntry
    {
        public new const ushort ProtocolId = 216;

        public override ushort TypeID => ProtocolId;

        public ushort Level { get; set; }
        public FightResultMutantListEntry() { }

        public FightResultMutantListEntry( ushort Level ){
            this.Level = Level;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUhShort();
        }
    }
}
