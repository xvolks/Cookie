using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Challenge
{
    public class ChallengeTargetsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5613;

        public ChallengeTargetsListMessage(List<double> targetIds, List<short> targetCells)
        {
            TargetIds = targetIds;
            TargetCells = targetCells;
        }

        public ChallengeTargetsListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<double> TargetIds { get; set; }
        public List<short> TargetCells { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) TargetIds.Count);
            for (var targetIdsIndex = 0; targetIdsIndex < TargetIds.Count; targetIdsIndex++)
                writer.WriteDouble(TargetIds[targetIdsIndex]);
            writer.WriteShort((short) TargetCells.Count);
            for (var targetCellsIndex = 0; targetCellsIndex < TargetCells.Count; targetCellsIndex++)
                writer.WriteShort(TargetCells[targetCellsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var targetIdsCount = reader.ReadUShort();
            TargetIds = new List<double>();
            for (var targetIdsIndex = 0; targetIdsIndex < targetIdsCount; targetIdsIndex++)
                TargetIds.Add(reader.ReadDouble());
            var targetCellsCount = reader.ReadUShort();
            TargetCells = new List<short>();
            for (var targetCellsIndex = 0; targetCellsIndex < targetCellsCount; targetCellsIndex++)
                TargetCells.Add(reader.ReadShort());
        }
    }
}