using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class KohUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6439;

        public override ushort MessageID => ProtocolId;

        public List<AllianceInformations> Alliances { get; set; }
        public List<short> AllianceNbMembers { get; set; }
        public List<int> AllianceRoundWeigth { get; set; }
        public List<sbyte> AllianceMatchScore { get; set; }
        public List<BasicAllianceInformations> AllianceMapWinners { get; set; }
        public uint AllianceMapWinnerScore { get; set; }
        public uint AllianceMapMyAllianceScore { get; set; }
        public double NextTickTime { get; set; }
        public KohUpdateMessage() { }

        public KohUpdateMessage( List<AllianceInformations> Alliances, List<short> AllianceNbMembers, List<int> AllianceRoundWeigth, List<sbyte> AllianceMatchScore, List<BasicAllianceInformations> AllianceMapWinners, uint AllianceMapWinnerScore, uint AllianceMapMyAllianceScore, double NextTickTime ){
            this.Alliances = Alliances;
            this.AllianceNbMembers = AllianceNbMembers;
            this.AllianceRoundWeigth = AllianceRoundWeigth;
            this.AllianceMatchScore = AllianceMatchScore;
            this.AllianceMapWinners = AllianceMapWinners;
            this.AllianceMapWinnerScore = AllianceMapWinnerScore;
            this.AllianceMapMyAllianceScore = AllianceMapMyAllianceScore;
            this.NextTickTime = NextTickTime;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Alliances.Count);
			foreach (var x in Alliances)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)AllianceNbMembers.Count);
			foreach (var x in AllianceNbMembers)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)AllianceRoundWeigth.Count);
			foreach (var x in AllianceRoundWeigth)
			{
				writer.WriteVarInt(x);
			}
			writer.WriteShort((short)AllianceMatchScore.Count);
			foreach (var x in AllianceMatchScore)
			{
				writer.WriteSByte(x);
			}
			writer.WriteShort((short)AllianceMapWinners.Count);
			foreach (var x in AllianceMapWinners)
			{
				x.Serialize(writer);
			}
            writer.WriteVarUhInt(AllianceMapWinnerScore);
            writer.WriteVarUhInt(AllianceMapMyAllianceScore);
            writer.WriteDouble(NextTickTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            var AlliancesCount = reader.ReadShort();
            Alliances = new List<AllianceInformations>();
            for (var i = 0; i < AlliancesCount; i++)
            {
                var objectToAdd = new AllianceInformations();
                objectToAdd.Deserialize(reader);
                Alliances.Add(objectToAdd);
            }
            var AllianceNbMembersCount = reader.ReadShort();
            AllianceNbMembers = new List<short>();
            for (var i = 0; i < AllianceNbMembersCount; i++)
            {
                AllianceNbMembers.Add(reader.ReadVarShort());
            }
            var AllianceRoundWeigthCount = reader.ReadShort();
            AllianceRoundWeigth = new List<int>();
            for (var i = 0; i < AllianceRoundWeigthCount; i++)
            {
                AllianceRoundWeigth.Add(reader.ReadVarInt());
            }
            var AllianceMatchScoreCount = reader.ReadShort();
            AllianceMatchScore = new List<sbyte>();
            for (var i = 0; i < AllianceMatchScoreCount; i++)
            {
                AllianceMatchScore.Add(reader.ReadSByte());
            }
            var AllianceMapWinnersCount = reader.ReadShort();
            AllianceMapWinners = new List<BasicAllianceInformations>();
            for (var i = 0; i < AllianceMapWinnersCount; i++)
            {
                var objectToAdd = new BasicAllianceInformations();
                objectToAdd.Deserialize(reader);
                AllianceMapWinners.Add(objectToAdd);
            }
            AllianceMapWinnerScore = reader.ReadVarUhInt();
            AllianceMapMyAllianceScore = reader.ReadVarUhInt();
            NextTickTime = reader.ReadDouble();
        }
    }
}
