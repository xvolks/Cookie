using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffectLadder : ObjectEffectCreature
    {
        public new const short ProtocolId = 81;
        public override short TypeId { get { return ProtocolId; } }

        public int MonsterCount = 0;

        public ObjectEffectLadder(): base()
        {
        }

        public ObjectEffectLadder(
            short actionId,
            short monsterFamilyId,
            int monsterCount
        ): base(
            actionId,
            monsterFamilyId
        )
        {
            MonsterCount = monsterCount;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(MonsterCount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MonsterCount = reader.ReadVarInt();
        }
    }
}