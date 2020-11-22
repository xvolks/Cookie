using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class InteractiveElementNamedSkill : InteractiveElementSkill
    {
        public new const short ProtocolId = 220;
        public override short TypeId { get { return ProtocolId; } }

        public int NameId = 0;

        public InteractiveElementNamedSkill(): base()
        {
        }

        public InteractiveElementNamedSkill(
            int skillId,
            int skillInstanceUid,
            int nameId
        ): base(
            skillId,
            skillInstanceUid
        )
        {
            NameId = nameId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(NameId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            NameId = reader.ReadVarInt();
        }
    }
}