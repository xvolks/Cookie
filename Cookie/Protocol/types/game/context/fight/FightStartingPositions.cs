using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class FightStartingPositions : NetworkType
    {
        public const short ProtocolId = 513;
        public override short TypeId { get { return ProtocolId; } }

        public List<short> PositionsForChallengers;
        public List<short> PositionsForDefenders;

        public FightStartingPositions()
        {
        }

        public FightStartingPositions(
            List<short> positionsForChallengers,
            List<short> positionsForDefenders
        )
        {
            PositionsForChallengers = positionsForChallengers;
            PositionsForDefenders = positionsForDefenders;
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
        }
    }
}