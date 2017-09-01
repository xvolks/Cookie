namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Types.Game.Context;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameContextMoveMultipleElementsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 254;
        public override ushort MessageID => ProtocolId;
        public List<EntityMovementInformations> Movements { get; set; }

        public GameContextMoveMultipleElementsMessage(List<EntityMovementInformations> movements)
        {
            Movements = movements;
        }

        public GameContextMoveMultipleElementsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Movements.Count);
            for (var movementsIndex = 0; movementsIndex < Movements.Count; movementsIndex++)
            {
                var objectToSend = Movements[movementsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var movementsCount = reader.ReadUShort();
            Movements = new List<EntityMovementInformations>();
            for (var movementsIndex = 0; movementsIndex < movementsCount; movementsIndex++)
            {
                var objectToAdd = new EntityMovementInformations();
                objectToAdd.Deserialize(reader);
                Movements.Add(objectToAdd);
            }
        }

    }
}
