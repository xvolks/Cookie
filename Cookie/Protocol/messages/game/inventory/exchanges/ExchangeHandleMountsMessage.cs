using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeHandleMountsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6752;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ActionType = 0;
        public List<int> RidesId;

        public ExchangeHandleMountsMessage()
        {
        }

        public ExchangeHandleMountsMessage(
            byte actionType,
            List<int> ridesId
        )
        {
            ActionType = actionType;
            RidesId = ridesId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(ActionType);
            writer.WriteShort((short)RidesId.Count());
            foreach (var current in RidesId)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ActionType = reader.ReadByte();
            var countRidesId = reader.ReadShort();
            RidesId = new List<int>();
            for (short i = 0; i < countRidesId; i++)
            {
                RidesId.Add(reader.ReadVarInt());
            }
        }
    }
}