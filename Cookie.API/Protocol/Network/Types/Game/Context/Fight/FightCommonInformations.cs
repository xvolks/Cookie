using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightCommonInformations : NetworkType
    {
        public const ushort ProtocolId = 43;

        public FightCommonInformations(int fightId, byte fightType, List<FightTeamInformations> fightTeams,
            List<ushort> fightTeamsPositions, List<FightOptionsInformations> fightTeamsOptions)
        {
            FightId = fightId;
            FightType = fightType;
            FightTeams = fightTeams;
            FightTeamsPositions = fightTeamsPositions;
            FightTeamsOptions = fightTeamsOptions;
        }

        public FightCommonInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int FightId { get; set; }
        public byte FightType { get; set; }
        public List<FightTeamInformations> FightTeams { get; set; }
        public List<ushort> FightTeamsPositions { get; set; }
        public List<FightOptionsInformations> FightTeamsOptions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteByte(FightType);
            writer.WriteShort((short) FightTeams.Count);
            for (var fightTeamsIndex = 0; fightTeamsIndex < FightTeams.Count; fightTeamsIndex++)
            {
                var objectToSend = FightTeams[fightTeamsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) FightTeamsPositions.Count);
            for (var fightTeamsPositionsIndex = 0;
                fightTeamsPositionsIndex < FightTeamsPositions.Count;
                fightTeamsPositionsIndex++)
                writer.WriteVarUhShort(FightTeamsPositions[fightTeamsPositionsIndex]);
            writer.WriteShort((short) FightTeamsOptions.Count);
            for (var fightTeamsOptionsIndex = 0;
                fightTeamsOptionsIndex < FightTeamsOptions.Count;
                fightTeamsOptionsIndex++)
            {
                var objectToSend = FightTeamsOptions[fightTeamsOptionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            FightType = reader.ReadByte();
            var fightTeamsCount = reader.ReadUShort();
            FightTeams = new List<FightTeamInformations>();
            for (var fightTeamsIndex = 0; fightTeamsIndex < fightTeamsCount; fightTeamsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<FightTeamInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                FightTeams.Add(objectToAdd);
            }
            var fightTeamsPositionsCount = reader.ReadUShort();
            FightTeamsPositions = new List<ushort>();
            for (var fightTeamsPositionsIndex = 0;
                fightTeamsPositionsIndex < fightTeamsPositionsCount;
                fightTeamsPositionsIndex++)
                FightTeamsPositions.Add(reader.ReadVarUhShort());
            var fightTeamsOptionsCount = reader.ReadUShort();
            FightTeamsOptions = new List<FightOptionsInformations>();
            for (var fightTeamsOptionsIndex = 0;
                fightTeamsOptionsIndex < fightTeamsOptionsCount;
                fightTeamsOptionsIndex++)
            {
                var objectToAdd = new FightOptionsInformations();
                objectToAdd.Deserialize(reader);
                FightTeamsOptions.Add(objectToAdd);
            }
        }
    }
}