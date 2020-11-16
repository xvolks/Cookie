using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameMapMovementRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 950;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> KeyMovements;
        public double MapId = 0;

        public GameMapMovementRequestMessage()
        {
        }

        public GameMapMovementRequestMessage(
            List<short> keyMovements,
            double mapId
        )
        {
            KeyMovements = keyMovements;
            MapId = mapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)KeyMovements.Count());
            foreach (var current in KeyMovements)
            {
                writer.WriteShort(current);
            }
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countKeyMovements = reader.ReadShort();
            KeyMovements = new List<short>();
            for (short i = 0; i < countKeyMovements; i++)
            {
                KeyMovements.Add(reader.ReadShort());
            }
            MapId = reader.ReadDouble();
        }
    }
}