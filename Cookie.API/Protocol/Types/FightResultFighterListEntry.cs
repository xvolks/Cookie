using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightResultFighterListEntry : FightResultListEntry
    {
        public new const ushort ProtocolId = 189;

        public override ushort TypeID => ProtocolId;

        public double Id { get; set; }
        public bool Alive { get; set; }
        public FightResultFighterListEntry() { }

        public FightResultFighterListEntry( double Id, bool Alive ){
            this.Id = Id;
            this.Alive = Alive;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(Id);
            writer.WriteBoolean(Alive);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Id = reader.ReadDouble();
            Alive = reader.ReadBoolean();
        }
    }
}
