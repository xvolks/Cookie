using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightFighterNamedInformations : GameFightFighterInformations
    {
        public new const short ProtocolId = 158;
        public override short TypeId { get { return ProtocolId; } }

        public string Name;
        public PlayerStatus Status;
        public short LeagueId = 0;
        public int LadderPosition = 0;
        public bool HiddenInPrefight = false;

        public GameFightFighterNamedInformations(): base()
        {
        }

        public GameFightFighterNamedInformations(
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
            bool hiddenInPrefight
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
            Name = name;
            Status = status;
            LeagueId = leagueId;
            LadderPosition = ladderPosition;
            HiddenInPrefight = hiddenInPrefight;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            Status.Serialize(writer);
            writer.WriteVarShort(LeagueId);
            writer.WriteInt(LadderPosition);
            writer.WriteBoolean(HiddenInPrefight);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
            LeagueId = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
            HiddenInPrefight = reader.ReadBoolean();
        }
    }
}