using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightPlacementPossiblePositionsMessage : NetworkMessage
    {
        public const uint ProtocolId = 703;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> PositionsForChallengers;
        public List<short> PositionsForDefenders;
        public byte TeamNumber = 2;

        public GameFightPlacementPossiblePositionsMessage()
        {
        }

        public GameFightPlacementPossiblePositionsMessage(
            List<short> positionsForChallengers,
            List<short> positionsForDefenders,
            byte teamNumber
        )
        {
            PositionsForChallengers = positionsForChallengers;
            PositionsForDefenders = positionsForDefenders;
            TeamNumber = teamNumber;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)PositionsForChallengers.Count());
            foreach (var current in PositionsForChallengers)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)PositionsForDefenders.Count());
            foreach (var current in PositionsForDefenders)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteByte(TeamNumber);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countPositionsForChallengers = reader.ReadShort();
            PositionsForChallengers = new List<short>();
            for (short i = 0; i < countPositionsForChallengers; i++)
            {
                PositionsForChallengers.Add(reader.ReadVarShort());
            }
            var countPositionsForDefenders = reader.ReadShort();
            PositionsForDefenders = new List<short>();
            for (short i = 0; i < countPositionsForDefenders; i++)
            {
                PositionsForDefenders.Add(reader.ReadVarShort());
            }
            TeamNumber = reader.ReadByte();
        }
    }
}