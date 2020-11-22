using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightMonsterInformations : GameFightAIInformations
    {
        public new const short ProtocolId = 29;
        public override short TypeId { get { return ProtocolId; } }

        public short CreatureGenericId = 0;
        public byte CreatureGrade = 0;
        public short CreatureLevel = 0;

        public GameFightMonsterInformations(): base()
        {
        }

        public GameFightMonsterInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            byte teamId,
            byte wave,
            bool alive,
            GameFightMinimalStats stats,
            List<short> previousPositions,
            short creatureGenericId,
            byte creatureGrade,
            short creatureLevel
        ): base(
            contextualId,
            look,
            disposition,
            teamId,
            wave,
            alive,
            stats,
            previousPositions
        )
        {
            CreatureGenericId = creatureGenericId;
            CreatureGrade = creatureGrade;
            CreatureLevel = creatureLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(CreatureGenericId);
            writer.WriteByte(CreatureGrade);
            writer.WriteShort(CreatureLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CreatureGenericId = reader.ReadVarShort();
            CreatureGrade = reader.ReadByte();
            CreatureLevel = reader.ReadShort();
        }
    }
}