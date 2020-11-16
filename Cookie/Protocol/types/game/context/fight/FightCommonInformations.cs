using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class FightCommonInformations : NetworkType
    {
        public const short ProtocolId = 43;
        public override short TypeId { get { return ProtocolId; } }

        public short FightId = 0;
        public byte FightType = 0;
        public List<FightTeamInformations> FightTeams;
        public List<short> FightTeamsPositions;
        public List<FightOptionsInformations> FightTeamsOptions;

        public FightCommonInformations()
        {
        }

        public FightCommonInformations(
            short fightId,
            byte fightType,
            List<FightTeamInformations> fightTeams,
            List<short> fightTeamsPositions,
            List<FightOptionsInformations> fightTeamsOptions
        )
        {
            FightId = fightId;
            FightType = fightType;
            FightTeams = fightTeams;
            FightTeamsPositions = fightTeamsPositions;
            FightTeamsOptions = fightTeamsOptions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteByte(FightType);
            writer.WriteShort((short)FightTeams.Count());
            foreach (var current in FightTeams)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)FightTeamsPositions.Count());
            foreach (var current in FightTeamsPositions)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)FightTeamsOptions.Count());
            foreach (var current in FightTeamsOptions)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            FightType = reader.ReadByte();
            var countFightTeams = reader.ReadShort();
            FightTeams = new List<FightTeamInformations>();
            for (short i = 0; i < countFightTeams; i++)
            {
                var fightTeamstypeId = reader.ReadShort();
                FightTeamInformations type = new FightTeamInformations();
                type.Deserialize(reader);
                FightTeams.Add(type);
            }
            var countFightTeamsPositions = reader.ReadShort();
            FightTeamsPositions = new List<short>();
            for (short i = 0; i < countFightTeamsPositions; i++)
            {
                FightTeamsPositions.Add(reader.ReadVarShort());
            }
            var countFightTeamsOptions = reader.ReadShort();
            FightTeamsOptions = new List<FightOptionsInformations>();
            for (short i = 0; i < countFightTeamsOptions; i++)
            {
                FightOptionsInformations type = new FightOptionsInformations();
                type.Deserialize(reader);
                FightTeamsOptions.Add(type);
            }
        }
    }
}