using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightStartingPositions : NetworkType
    {
        public const ushort ProtocolId = 513;

        public FightStartingPositions(List<ushort> positionsForChallengers, List<ushort> positionsForDefenders)
        {
            PositionsForChallengers = positionsForChallengers;
            PositionsForDefenders = positionsForDefenders;
        }

        public FightStartingPositions()
        {
        }

        public override ushort TypeID => ProtocolId;
        public List<ushort> PositionsForChallengers { get; set; }
        public List<ushort> PositionsForDefenders { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) PositionsForChallengers.Count);
            for (var positionsForChallengersIndex = 0;
                positionsForChallengersIndex < PositionsForChallengers.Count;
                positionsForChallengersIndex++)
                writer.WriteVarUhShort(PositionsForChallengers[positionsForChallengersIndex]);
            writer.WriteShort((short) PositionsForDefenders.Count);
            for (var positionsForDefendersIndex = 0;
                positionsForDefendersIndex < PositionsForDefenders.Count;
                positionsForDefendersIndex++)
                writer.WriteVarUhShort(PositionsForDefenders[positionsForDefendersIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var positionsForChallengersCount = reader.ReadUShort();
            PositionsForChallengers = new List<ushort>();
            for (var positionsForChallengersIndex = 0;
                positionsForChallengersIndex < positionsForChallengersCount;
                positionsForChallengersIndex++)
                PositionsForChallengers.Add(reader.ReadVarUhShort());
            var positionsForDefendersCount = reader.ReadUShort();
            PositionsForDefenders = new List<ushort>();
            for (var positionsForDefendersIndex = 0;
                positionsForDefendersIndex < positionsForDefendersCount;
                positionsForDefendersIndex++)
                PositionsForDefenders.Add(reader.ReadVarUhShort());
        }
    }
}