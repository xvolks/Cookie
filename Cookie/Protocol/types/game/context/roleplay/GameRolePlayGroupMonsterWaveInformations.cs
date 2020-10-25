using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayGroupMonsterWaveInformations : GameRolePlayGroupMonsterInformations
    {
        public new const short ProtocolId = 464;
        public override short TypeId { get { return ProtocolId; } }

        public byte NbWaves = 0;
        public List<GroupMonsterStaticInformations> Alternatives;

        public GameRolePlayGroupMonsterWaveInformations(): base()
        {
        }

        public GameRolePlayGroupMonsterWaveInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            bool keyRingBonus,
            bool hasHardcoreDrop,
            bool hasAVARewardToken,
            GroupMonsterStaticInformations staticInfos,
            byte lootShare,
            byte alignmentSide,
            byte nbWaves,
            List<GroupMonsterStaticInformations> alternatives
        ): base(
            contextualId,
            look,
            disposition,
            keyRingBonus,
            hasHardcoreDrop,
            hasAVARewardToken,
            staticInfos,
            lootShare,
            alignmentSide
        )
        {
            NbWaves = nbWaves;
            Alternatives = alternatives;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(NbWaves);
            writer.WriteShort((short)Alternatives.Count());
            foreach (var current in Alternatives)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            NbWaves = reader.ReadByte();
            var countAlternatives = reader.ReadShort();
            Alternatives = new List<GroupMonsterStaticInformations>();
            for (short i = 0; i < countAlternatives; i++)
            {
                var alternativestypeId = reader.ReadShort();
                GroupMonsterStaticInformations type = new GroupMonsterStaticInformations();
                type.Deserialize(reader);
                Alternatives.Add(type);
            }
        }
    }
}