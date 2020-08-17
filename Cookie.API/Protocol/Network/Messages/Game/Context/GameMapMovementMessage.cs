using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameMapMovementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 951;

        public GameMapMovementMessage(List<short> keyMovements, short forcedDirection, double actorId)
        {
            KeyMovements = keyMovements;
            ForcedDirection = forcedDirection;
            ActorId = actorId;
        }

        public GameMapMovementMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<short> KeyMovements { get; set; }
        public short ForcedDirection { get; set; }
        public double ActorId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) KeyMovements.Count);
            for (var keyMovementsIndex = 0; keyMovementsIndex < KeyMovements.Count; keyMovementsIndex++)
                writer.WriteShort(KeyMovements[keyMovementsIndex]);
            writer.WriteShort(ForcedDirection);
            writer.WriteDouble(ActorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var keyMovementsCount = reader.ReadUShort();
            KeyMovements = new List<short>();
            for (var keyMovementsIndex = 0; keyMovementsIndex < keyMovementsCount; keyMovementsIndex++)
                KeyMovements.Add(reader.ReadShort());
            ForcedDirection = reader.ReadShort();
            ActorId = reader.ReadDouble();
        }
    }
}