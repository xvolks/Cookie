using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightExternalInformations : NetworkType
    {
        public const ushort ProtocolId = 117;

        public override ushort TypeID => ProtocolId;

        public ushort FightId { get; set; }
        public sbyte FightType { get; set; }
        public int FightStart { get; set; }
        public bool FightSpectatorLocked { get; set; }
        public List<FightTeamLightInformations> FightTeams { get; set; }
        public List<FightOptionsInformations> FightTeamsOptions { get; set; }
        public FightExternalInformations() { }

        public FightExternalInformations( ushort FightId, sbyte FightType, int FightStart, bool FightSpectatorLocked, List<FightTeamLightInformations> FightTeams, List<FightOptionsInformations> FightTeamsOptions ){
            this.FightId = FightId;
            this.FightType = FightType;
            this.FightStart = FightStart;
            this.FightSpectatorLocked = FightSpectatorLocked;
            this.FightTeams = FightTeams;
            this.FightTeamsOptions = FightTeamsOptions;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
            writer.WriteSByte(FightType);
            writer.WriteInt(FightStart);
            writer.WriteBoolean(FightSpectatorLocked);
			if(FightTeams.Count > 2) throw new System.Exception("FightTeams Count returned greater than 2");
			foreach (var x in FightTeams)
			{
				x.Serialize(writer);
			}
			if(FightTeamsOptions.Count > 2) throw new System.Exception("FightTeamsOptions Count returned greater than 2");
			foreach (var x in FightTeamsOptions)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            FightType = reader.ReadSByte();
            FightStart = reader.ReadInt();
            FightSpectatorLocked = reader.ReadBoolean();
            var FightTeamsCount = 2;
            FightTeams = new List<FightTeamLightInformations>();
            for (var i = 0; i < FightTeamsCount; i++)
            {
                var objectToAdd = new FightTeamLightInformations();
                objectToAdd.Deserialize(reader);
                FightTeams.Add(objectToAdd);
            }
            var FightTeamsOptionsCount = 2;
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
