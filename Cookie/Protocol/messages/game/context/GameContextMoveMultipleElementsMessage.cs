using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextMoveMultipleElementsMessage : NetworkMessage
    {
        public const uint ProtocolId = 254;
        public override uint MessageID { get { return ProtocolId; } }

        public List<EntityMovementInformations> Movements;

        public GameContextMoveMultipleElementsMessage()
        {
        }

        public GameContextMoveMultipleElementsMessage(
            List<EntityMovementInformations> movements
        )
        {
            Movements = movements;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Movements.Count());
            foreach (var current in Movements)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countMovements = reader.ReadShort();
            Movements = new List<EntityMovementInformations>();
            for (short i = 0; i < countMovements; i++)
            {
                EntityMovementInformations type = new EntityMovementInformations();
                type.Deserialize(reader);
                Movements.Add(type);
            }
        }
    }
}