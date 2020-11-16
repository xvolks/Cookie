using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightStartingPositions : NetworkType
    {
        public const ushort ProtocolId = 513;

        public override ushort TypeID => ProtocolId;

        public List<short> PositionsForChallengers { get; set; }
        public List<short> PositionsForDefenders { get; set; }
        public FightStartingPositions() { }

        public FightStartingPositions( List<short> PositionsForChallengers, List<short> PositionsForDefenders ){
            this.PositionsForChallengers = PositionsForChallengers;
            this.PositionsForDefenders = PositionsForDefenders;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)PositionsForChallengers.Count);
			foreach (var x in PositionsForChallengers)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)PositionsForDefenders.Count);
			foreach (var x in PositionsForDefenders)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var PositionsForChallengersCount = reader.ReadShort();
            PositionsForChallengers = new List<short>();
            for (var i = 0; i < PositionsForChallengersCount; i++)
            {
                PositionsForChallengers.Add(reader.ReadVarShort());
            }
            var PositionsForDefendersCount = reader.ReadShort();
            PositionsForDefenders = new List<short>();
            for (var i = 0; i < PositionsForDefendersCount; i++)
            {
                PositionsForDefenders.Add(reader.ReadVarShort());
            }
        }
    }
}
