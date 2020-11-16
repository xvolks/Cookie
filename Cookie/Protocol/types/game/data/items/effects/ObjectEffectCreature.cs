using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffectCreature : ObjectEffect
    {
        public new const short ProtocolId = 71;
        public override short TypeId { get { return ProtocolId; } }

        public short MonsterFamilyId = 0;

        public ObjectEffectCreature(): base()
        {
        }

        public ObjectEffectCreature(
            short actionId,
            short monsterFamilyId
        ): base(
            actionId
        )
        {
            MonsterFamilyId = monsterFamilyId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(MonsterFamilyId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MonsterFamilyId = reader.ReadVarShort();
        }
    }
}