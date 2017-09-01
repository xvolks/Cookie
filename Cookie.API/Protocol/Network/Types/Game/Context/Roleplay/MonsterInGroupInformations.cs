using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class MonsterInGroupInformations : MonsterInGroupLightInformations
    {
        public new const ushort ProtocolId = 144;

        public MonsterInGroupInformations(EntityLook look)
        {
            Look = look;
        }

        public MonsterInGroupInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public EntityLook Look { get; set; }

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