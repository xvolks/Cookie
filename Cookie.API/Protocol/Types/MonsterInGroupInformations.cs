using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class MonsterInGroupInformations : MonsterInGroupLightInformations
    {
        public new const ushort ProtocolId = 144;

        public override ushort TypeID => ProtocolId;

        public EntityLook Look { get; set; }
        public MonsterInGroupInformations() { }

        public MonsterInGroupInformations( EntityLook Look ){
            this.Look = Look;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}
