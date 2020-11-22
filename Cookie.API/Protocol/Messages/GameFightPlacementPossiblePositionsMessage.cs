using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightPlacementPossiblePositionsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 703;

        public override ushort MessageID => ProtocolId;

        public List<short> PositionsForChallengers { get; set; }
        public List<short> PositionsForDefenders { get; set; }
        public sbyte TeamNumber { get; set; }
        public GameFightPlacementPossiblePositionsMessage() { }

        public GameFightPlacementPossiblePositionsMessage( List<short> PositionsForChallengers, List<short> PositionsForDefenders, sbyte TeamNumber ){
            this.PositionsForChallengers = PositionsForChallengers;
            this.PositionsForDefenders = PositionsForDefenders;
            this.TeamNumber = TeamNumber;
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
            writer.WriteSByte(TeamNumber);
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
            TeamNumber = reader.ReadSByte();
        }
    }
}
