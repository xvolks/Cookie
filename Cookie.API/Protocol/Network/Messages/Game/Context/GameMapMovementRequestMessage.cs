using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameMapMovementRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 950;

        public GameMapMovementRequestMessage(List<short> keyMovements, int mapId)
        {
            KeyMovements = keyMovements;
            MapId = mapId;
        }

        public GameMapMovementRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<short> KeyMovements { get; set; }
        public int MapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) KeyMovements.Count);
            for (var keyMovementsIndex = 0; keyMovementsIndex < KeyMovements.Count; keyMovementsIndex++)
                writer.WriteShort(KeyMovements[keyMovementsIndex]);
            writer.WriteInt(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var keyMovementsCount = reader.ReadUShort();
            KeyMovements = new List<short>();
            for (var keyMovementsIndex = 0; keyMovementsIndex < keyMovementsCount; keyMovementsIndex++)
                KeyMovements.Add(reader.ReadShort());
            MapId = reader.ReadInt();
        }
    }
}