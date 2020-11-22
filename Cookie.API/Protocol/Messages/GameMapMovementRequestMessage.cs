using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameMapMovementRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 950;

        public override ushort MessageID => ProtocolId;

        public List<short> KeyMovements { get; set; }
        public double MapId { get; set; }
        public GameMapMovementRequestMessage() { }

        public GameMapMovementRequestMessage( List<short> KeyMovements, double MapId ){
            this.KeyMovements = KeyMovements;
            this.MapId = MapId;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)KeyMovements.Count);
			foreach (var x in KeyMovements)
			{
				writer.WriteShort(x);
			}
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var KeyMovementsCount = reader.ReadShort();
            KeyMovements = new List<short>();
            for (var i = 0; i < KeyMovementsCount; i++)
            {
                KeyMovements.Add(reader.ReadShort());
            }
            MapId = reader.ReadDouble();
        }
    }
}
