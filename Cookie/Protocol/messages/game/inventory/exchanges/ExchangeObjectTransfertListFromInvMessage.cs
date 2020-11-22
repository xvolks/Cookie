using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectTransfertListFromInvMessage : NetworkMessage
    {
        public const uint ProtocolId = 6183;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> Ids;

        public ExchangeObjectTransfertListFromInvMessage()
        {
        }

        public ExchangeObjectTransfertListFromInvMessage(
            List<int> ids
        )
        {
            Ids = ids;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Ids.Count());
            foreach (var current in Ids)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countIds = reader.ReadShort();
            Ids = new List<int>();
            for (short i = 0; i < countIds; i++)
            {
                Ids.Add(reader.ReadVarInt());
            }
        }
    }
}