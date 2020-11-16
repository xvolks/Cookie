using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameContextMoveMultipleElementsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 254;

        public override ushort MessageID => ProtocolId;

        public List<EntityMovementInformations> Movements { get; set; }
        public GameContextMoveMultipleElementsMessage() { }

        public GameContextMoveMultipleElementsMessage( List<EntityMovementInformations> Movements ){
            this.Movements = Movements;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Movements.Count);
			foreach (var x in Movements)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var MovementsCount = reader.ReadShort();
            Movements = new List<EntityMovementInformations>();
            for (var i = 0; i < MovementsCount; i++)
            {
                var objectToAdd = new EntityMovementInformations();
                objectToAdd.Deserialize(reader);
                Movements.Add(objectToAdd);
            }
        }
    }
}
