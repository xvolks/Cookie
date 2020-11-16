using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightFighterMonsterLightInformations : GameFightFighterLightInformations
    {
        public new const short ProtocolId = 455;
        public override short TypeId { get { return ProtocolId; } }

        public short CreatureGenericId = 0;

        public GameFightFighterMonsterLightInformations(): base()
        {
        }

        public GameFightFighterMonsterLightInformations(
            bool sex,
            bool alive,
            double id_,
            byte wave,
            short level,
            byte breed,
            short creatureGenericId
        ): base(
            sex,
            alive,
            id_,
            wave,
            level,
            breed
        )
        {
            CreatureGenericId = creatureGenericId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(CreatureGenericId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CreatureGenericId = reader.ReadVarShort();
        }
    }
}