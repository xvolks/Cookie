using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChallengeTargetsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5613;

        public override ushort MessageID => ProtocolId;

        public List<double> TargetIds { get; set; }
        public List<short> TargetCells { get; set; }
        public ChallengeTargetsListMessage() { }

        public ChallengeTargetsListMessage( List<double> TargetIds, List<short> TargetCells ){
            this.TargetIds = TargetIds;
            this.TargetCells = TargetCells;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)TargetIds.Count);
			foreach (var x in TargetIds)
			{
				writer.WriteDouble(x);
			}
			writer.WriteShort((short)TargetCells.Count);
			foreach (var x in TargetCells)
			{
				writer.WriteShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var TargetIdsCount = reader.ReadShort();
            TargetIds = new List<double>();
            for (var i = 0; i < TargetIdsCount; i++)
            {
                TargetIds.Add(reader.ReadDouble());
            }
            var TargetCellsCount = reader.ReadShort();
            TargetCells = new List<short>();
            for (var i = 0; i < TargetCellsCount; i++)
            {
                TargetCells.Add(reader.ReadShort());
            }
        }
    }
}
