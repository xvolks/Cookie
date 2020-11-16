using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class FightExternalInformations : NetworkType
    {
        public const short ProtocolId = 117;
        public override short TypeId { get { return ProtocolId; } }

        public short FightId = 0;
        public byte FightType = 0;
        public int FightStart = 0;
        public bool FightSpectatorLocked = false;
        public List<FightTeamLightInformations> FightTeams;
        public List<FightOptionsInformations> FightTeamsOptions;

        public FightExternalInformations()
        {
        }

        public FightExternalInformations(
            short fightId,
            byte fightType,
            int fightStart,
            bool fightSpectatorLocked,
            List<FightTeamLightInformations> fightTeams,
            List<FightOptionsInformations> fightTeamsOptions
        )
        {
            FightId = fightId;
            FightType = fightType;
            FightStart = fightStart;
            FightSpectatorLocked = fightSpectatorLocked;
            FightTeams = fightTeams;
            FightTeamsOptions = fightTeamsOptions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteByte(FightType);
            writer.WriteInt(FightStart);
            writer.WriteBoolean(FightSpectatorLocked);
            foreach (var current in FightTeams)
            {
                current.Serialize(writer);
            }
            foreach (var current in FightTeamsOptions)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            FightType = reader.ReadByte();
            FightStart = reader.ReadInt();
            FightSpectatorLocked = reader.ReadBoolean();
            FightTeams = new List<FightTeamLightInformations>();
            for (int i = 0; i < 2; i++)
            {
                FightTeamLightInformations type = new FightTeamLightInformations();
                type.Deserialize(reader);
                FightTeams.Add(type);
            }
            FightTeamsOptions = new List<FightOptionsInformations>();
            for (int i = 0; i < 2; i++)
            {
                FightOptionsInformations type = new FightOptionsInformations();
                type.Deserialize(reader);
                FightTeamsOptions.Add(type);
            }
        }
    }
}