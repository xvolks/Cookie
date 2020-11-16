using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectEffectCreature : ObjectEffect
    {
        public new const ushort ProtocolId = 71;

        public override ushort TypeID => ProtocolId;

        public ushort MonsterFamilyId { get; set; }
        public ObjectEffectCreature() { }

        public ObjectEffectCreature( ushort MonsterFamilyId ){
            this.MonsterFamilyId = MonsterFamilyId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(MonsterFamilyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MonsterFamilyId = reader.ReadVarUhShort();
        }
    }
}
