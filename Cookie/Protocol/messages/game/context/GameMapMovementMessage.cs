using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameMapMovementMessage : NetworkMessage
    {
        public const uint ProtocolId = 951;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> KeyMovements;
        public short ForcedDirection = 0;
        public double ActorId = 0;

        public GameMapMovementMessage()
        {
        }

        public GameMapMovementMessage(
            List<short> keyMovements,
            short forcedDirection,
            double actorId
        )
        {
            KeyMovements = keyMovements;
            ForcedDirection = forcedDirection;
            ActorId = actorId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)KeyMovements.Count());
            foreach (var current in KeyMovements)
            {
                writer.WriteShort(current);
            }
            writer.WriteShort(ForcedDirection);
            writer.WriteDouble(ActorId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countKeyMovements = reader.ReadShort();
            KeyMovements = new List<short>();
            for (short i = 0; i < countKeyMovements; i++)
            {
                KeyMovements.Add(reader.ReadShort());
            }
            ForcedDirection = reader.ReadShort();
            ActorId = reader.ReadDouble();
        }
    }
}