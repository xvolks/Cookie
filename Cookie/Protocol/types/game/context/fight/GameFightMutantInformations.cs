using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightMutantInformations : GameFightFighterNamedInformations
    {
        public new const short ProtocolId = 50;
        public override short TypeId { get { return ProtocolId; } }

        public byte PowerLevel = 0;

        public GameFightMutantInformations(): base()
        {
        }

        public GameFightMutantInformations(
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
            byte powerLevel
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
            PowerLevel = powerLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PowerLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PowerLevel = reader.ReadByte();
        }
    }
}