using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameMapMovementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 951;

        public override ushort MessageID => ProtocolId;

        public List<short> KeyMovements { get; set; }
        public short ForcedDirection { get; set; }
        public double ActorId { get; set; }
        public GameMapMovementMessage() { }

        public GameMapMovementMessage( List<short> KeyMovements, short ForcedDirection, double ActorId ){
            this.KeyMovements = KeyMovements;
            this.ForcedDirection = ForcedDirection;
            this.ActorId = ActorId;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)KeyMovements.Count);
			foreach (var x in KeyMovements)
			{
				writer.WriteShort(x);
			}
            writer.WriteShort(ForcedDirection);
            writer.WriteDouble(ActorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var KeyMovementsCount = reader.ReadShort();
            KeyMovements = new List<short>();
            for (var i = 0; i < KeyMovementsCount; i++)
            {
                KeyMovements.Add(reader.ReadShort());
            }
            ForcedDirection = reader.ReadShort();
            ActorId = reader.ReadDouble();
        }
    }
}
