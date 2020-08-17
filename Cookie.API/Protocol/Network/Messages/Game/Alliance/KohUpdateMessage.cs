using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class KohUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6439;

        public KohUpdateMessage(List<AllianceInformations> alliances, List<ushort> allianceNbMembers,
            List<uint> allianceRoundWeigth, List<byte> allianceMatchScore, BasicAllianceInformations allianceMapWinner,
            uint allianceMapWinnerScore, uint allianceMapMyAllianceScore, double nextTickTime)
        {
            Alliances = alliances;
            AllianceNbMembers = allianceNbMembers;
            AllianceRoundWeigth = allianceRoundWeigth;
            AllianceMatchScore = allianceMatchScore;
            AllianceMapWinner = allianceMapWinner;
            AllianceMapWinnerScore = allianceMapWinnerScore;
            AllianceMapMyAllianceScore = allianceMapMyAllianceScore;
            NextTickTime = nextTickTime;
        }

        public KohUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<AllianceInformations> Alliances { get; set; }
        public List<ushort> AllianceNbMembers { get; set; }
        public List<uint> AllianceRoundWeigth { get; set; }
        public List<byte> AllianceMatchScore { get; set; }
        public BasicAllianceInformations AllianceMapWinner { get; set; }
        public uint AllianceMapWinnerScore { get; set; }
        public uint AllianceMapMyAllianceScore { get; set; }
        public double NextTickTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Alliances.Count);
            for (var alliancesIndex = 0; alliancesIndex < Alliances.Count; alliancesIndex++)
            {
                var objectToSend = Alliances[alliancesIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) AllianceNbMembers.Count);
            for (var allianceNbMembersIndex = 0;
                allianceNbMembersIndex < AllianceNbMembers.Count;
                allianceNbMembersIndex++)
                writer.WriteVarUhShort(AllianceNbMembers[allianceNbMembersIndex]);
            writer.WriteShort((short) AllianceRoundWeigth.Count);
            for (var allianceRoundWeigthIndex = 0;
                allianceRoundWeigthIndex < AllianceRoundWeigth.Count;
                allianceRoundWeigthIndex++)
                writer.WriteVarUhInt(AllianceRoundWeigth[allianceRoundWeigthIndex]);
            writer.WriteShort((short) AllianceMatchScore.Count);
            for (var allianceMatchScoreIndex = 0;
                allianceMatchScoreIndex < AllianceMatchScore.Count;
                allianceMatchScoreIndex++)
                writer.WriteByte(AllianceMatchScore[allianceMatchScoreIndex]);
            AllianceMapWinner.Serialize(writer);
            writer.WriteVarUhInt(AllianceMapWinnerScore);
            writer.WriteVarUhInt(AllianceMapMyAllianceScore);
            writer.WriteDouble(NextTickTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            var alliancesCount = reader.ReadUShort();
            Alliances = new List<AllianceInformations>();
            for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
            {
                var objectToAdd = new AllianceInformations();
                objectToAdd.Deserialize(reader);
                Alliances.Add(objectToAdd);
            }
            var allianceNbMembersCount = reader.ReadUShort();
            AllianceNbMembers = new List<ushort>();
            for (var allianceNbMembersIndex = 0;
                allianceNbMembersIndex < allianceNbMembersCount;
                allianceNbMembersIndex++)
                AllianceNbMembers.Add(reader.ReadVarUhShort());
            var allianceRoundWeigthCount = reader.ReadUShort();
            AllianceRoundWeigth = new List<uint>();
            for (var allianceRoundWeigthIndex = 0;
                allianceRoundWeigthIndex < allianceRoundWeigthCount;
                allianceRoundWeigthIndex++)
                AllianceRoundWeigth.Add(reader.ReadVarUhInt());
            var allianceMatchScoreCount = reader.ReadUShort();
            AllianceMatchScore = new List<byte>();
            for (var allianceMatchScoreIndex = 0;
                allianceMatchScoreIndex < allianceMatchScoreCount;
                allianceMatchScoreIndex++)
                AllianceMatchScore.Add(reader.ReadByte());
            AllianceMapWinner = new BasicAllianceInformations();
            AllianceMapWinner.Deserialize(reader);
            AllianceMapWinnerScore = reader.ReadVarUhInt();
            AllianceMapMyAllianceScore = reader.ReadVarUhInt();
            NextTickTime = reader.ReadDouble();
        }
    }
}