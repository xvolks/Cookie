using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ChallengeTargetsListMessage : NetworkMessage
    {
        public const uint ProtocolId = 5613;
        public override uint MessageID { get { return ProtocolId; } }

        public List<double> TargetIds;
        public List<short> TargetCells;

        public ChallengeTargetsListMessage()
        {
        }

        public ChallengeTargetsListMessage(
            List<double> targetIds,
            List<short> targetCells
        )
        {
            TargetIds = targetIds;
            TargetCells = targetCells;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)TargetIds.Count());
            foreach (var current in TargetIds)
            {
                writer.WriteDouble(current);
            }
            writer.WriteShort((short)TargetCells.Count());
            foreach (var current in TargetCells)
            {
                writer.WriteShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countTargetIds = reader.ReadShort();
            TargetIds = new List<double>();
            for (short i = 0; i < countTargetIds; i++)
            {
                TargetIds.Add(reader.ReadDouble());
            }
            var countTargetCells = reader.ReadShort();
            TargetCells = new List<short>();
            for (short i = 0; i < countTargetCells; i++)
            {
                TargetCells.Add(reader.ReadShort());
            }
        }
    }
}