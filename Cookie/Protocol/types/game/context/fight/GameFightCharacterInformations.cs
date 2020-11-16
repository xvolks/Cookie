using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightCharacterInformations : GameFightFighterNamedInformations
    {
        public new const short ProtocolId = 46;
        public override short TypeId { get { return ProtocolId; } }

        public short Level = 0;
        public ActorAlignmentInformations AlignmentInfos;
        public byte Breed = 0;
        public bool Sex = false;

        public GameFightCharacterInformations(): base()
        {
        }

        public GameFightCharacterInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            byte teamId,
            byte wave,
            bool alive,
            GameFightMinimalStats stats,
            List<short> previousPositions,
            string name,
            PlayerStatus status,
            short leagueId,
            int ladderPosition,
            bool hiddenInPrefight,
            short level,
            ActorAlignmentInformations alignmentInfos,
            byte breed,
            bool sex
        ): base(
            contextualId,
            look,
            disposition,
            teamId,
            wave,
            alive,
            stats,
            previousPositions,
            name,
            status,
            leagueId,
            ladderPosition,
            hiddenInPrefight
        )
        {
            Level = level;
            AlignmentInfos = alignmentInfos;
            Breed = breed;
            Sex = sex;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Level);
            AlignmentInfos.Serialize(writer);
            writer.WriteByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarShort();
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
            Breed = reader.ReadByte();
            Sex = reader.ReadBoolean();
        }
    }
}