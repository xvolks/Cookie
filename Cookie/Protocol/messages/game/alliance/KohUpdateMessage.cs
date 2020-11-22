using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class KohUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6439;
        public override uint MessageID { get { return ProtocolId; } }

        public List<AllianceInformations> Alliances;
        public List<short> AllianceNbMembers;
        public List<int> AllianceRoundWeigth;
        public List<byte> AllianceMatchScore;
        public List<BasicAllianceInformations> AllianceMapWinners;
        public int AllianceMapWinnerScore = 0;
        public int AllianceMapMyAllianceScore = 0;
        public double NextTickTime = 0;

        public KohUpdateMessage()
        {
        }

        public KohUpdateMessage(
            List<AllianceInformations> alliances,
            List<short> allianceNbMembers,
            List<int> allianceRoundWeigth,
            List<byte> allianceMatchScore,
            List<BasicAllianceInformations> allianceMapWinners,
            int allianceMapWinnerScore,
            int allianceMapMyAllianceScore,
            double nextTickTime
        )
        {
            Alliances = alliances;
            AllianceNbMembers = allianceNbMembers;
            AllianceRoundWeigth = allianceRoundWeigth;
            AllianceMatchScore = allianceMatchScore;
            AllianceMapWinners = allianceMapWinners;
            AllianceMapWinnerScore = allianceMapWinnerScore;
            AllianceMapMyAllianceScore = allianceMapMyAllianceScore;
            NextTickTime = nextTickTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Alliances.Count());
            foreach (var current in Alliances)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)AllianceNbMembers.Count());
            foreach (var current in AllianceNbMembers)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)AllianceRoundWeigth.Count());
            foreach (var current in AllianceRoundWeigth)
            {
                writer.WriteVarInt(current);
            }
            writer.WriteShort((short)AllianceMatchScore.Count());
            foreach (var current in AllianceMatchScore)
            {
                writer.WriteByte(current);
            }
            writer.WriteShort((short)AllianceMapWinners.Count());
            foreach (var current in AllianceMapWinners)
            {
                current.Serialize(writer);
            }
            writer.WriteVarInt(AllianceMapWinnerScore);
            writer.WriteVarInt(AllianceMapMyAllianceScore);
            writer.WriteDouble(NextTickTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countAlliances = reader.ReadShort();
            Alliances = new List<AllianceInformations>();
            for (short i = 0; i < countAlliances; i++)
            {
                AllianceInformations type = new AllianceInformations();
                type.Deserialize(reader);
                Alliances.Add(type);
            }
            var countAllianceNbMembers = reader.ReadShort();
            AllianceNbMembers = new List<short>();
            for (short i = 0; i < countAllianceNbMembers; i++)
            {
                AllianceNbMembers.Add(reader.ReadVarShort());
            }
            var countAllianceRoundWeigth = reader.ReadShort();
            AllianceRoundWeigth = new List<int>();
            for (short i = 0; i < countAllianceRoundWeigth; i++)
            {
                AllianceRoundWeigth.Add(reader.ReadVarInt());
            }
            var countAllianceMatchScore = reader.ReadShort();
            AllianceMatchScore = new List<byte>();
            for (short i = 0; i < countAllianceMatchScore; i++)
            {
                AllianceMatchScore.Add(reader.ReadByte());
            }
            var countAllianceMapWinners = reader.ReadShort();
            AllianceMapWinners = new List<BasicAllianceInformations>();
            for (short i = 0; i < countAllianceMapWinners; i++)
            {
                BasicAllianceInformations type = new BasicAllianceInformations();
                type.Deserialize(reader);
                AllianceMapWinners.Add(type);
            }
            AllianceMapWinnerScore = reader.ReadVarInt();
            AllianceMapMyAllianceScore = reader.ReadVarInt();
            NextTickTime = reader.ReadDouble();
        }
    }
}