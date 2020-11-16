using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightCommonInformations : NetworkType
    {
        public const ushort ProtocolId = 43;

        public override ushort TypeID => ProtocolId;

        public ushort FightId { get; set; }
        public sbyte FightType { get; set; }
        public List<FightTeamInformations> FightTeams { get; set; }
        public List<short> FightTeamsPositions { get; set; }
        public List<FightOptionsInformations> FightTeamsOptions { get; set; }
        public FightCommonInformations() { }

        public FightCommonInformations( ushort FightId, sbyte FightType, List<FightTeamInformations> FightTeams, List<short> FightTeamsPositions, List<FightOptionsInformations> FightTeamsOptions ){
            this.FightId = FightId;
            this.FightType = FightType;
            this.FightTeams = FightTeams;
            this.FightTeamsPositions = FightTeamsPositions;
            this.FightTeamsOptions = FightTeamsOptions;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
            writer.WriteSByte(FightType);
			writer.WriteShort((short)FightTeams.Count);
			foreach (var x in FightTeams)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)FightTeamsPositions.Count);
			foreach (var x in FightTeamsPositions)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)FightTeamsOptions.Count);
			foreach (var x in FightTeamsOptions)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            FightType = reader.ReadSByte();
            var FightTeamsCount = reader.ReadShort();
            FightTeams = new List<FightTeamInformations>();
            for (var i = 0; i < FightTeamsCount; i++)
            {
                FightTeamInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                FightTeams.Add(objectToAdd);
            }
            var FightTeamsPositionsCount = reader.ReadShort();
            FightTeamsPositions = new List<short>();
            for (var i = 0; i < FightTeamsPositionsCount; i++)
            {
                FightTeamsPositions.Add(reader.ReadVarShort());
            }
            var FightTeamsOptionsCount = reader.ReadShort();
            FightTeamsOptions = new List<FightOptionsInformations>();
            for (var i = 0; i < FightTeamsOptionsCount; i++)
            {
                var objectToAdd = new FightOptionsInformations();
                objectToAdd.Deserialize(reader);
                FightTeamsOptions.Add(objectToAdd);
            }
        }
    }
}
