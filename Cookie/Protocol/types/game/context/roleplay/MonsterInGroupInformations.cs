using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class MonsterInGroupInformations : MonsterInGroupLightInformations
    {
        public new const short ProtocolId = 144;
        public override short TypeId { get { return ProtocolId; } }

        public EntityLook Look;

        public MonsterInGroupInformations(): base()
        {
        }

        public MonsterInGroupInformations(
            int genericId,
            byte grade,
            short level,
            EntityLook look
        ): base(
            genericId,
            grade,
            level
        )
        {
            Look = look;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Look.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}