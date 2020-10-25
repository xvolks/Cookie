using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeTypesExchangerDescriptionForUserMessage : NetworkMessage
    {
        public const uint ProtocolId = 5765;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> TypeDescription;

        public ExchangeTypesExchangerDescriptionForUserMessage()
        {
        }

        public ExchangeTypesExchangerDescriptionForUserMessage(
            List<int> typeDescription
        )
        {
            TypeDescription = typeDescription;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)TypeDescription.Count());
            foreach (var current in TypeDescription)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countTypeDescription = reader.ReadShort();
            TypeDescription = new List<int>();
            for (short i = 0; i < countTypeDescription; i++)
            {
                TypeDescription.Add(reader.ReadVarInt());
            }
        }
    }
}