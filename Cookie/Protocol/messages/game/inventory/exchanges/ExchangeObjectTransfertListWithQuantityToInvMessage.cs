using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectTransfertListWithQuantityToInvMessage : NetworkMessage
    {
        public const uint ProtocolId = 6470;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> Ids;
        public List<int> Qtys;

        public ExchangeObjectTransfertListWithQuantityToInvMessage()
        {
        }

        public ExchangeObjectTransfertListWithQuantityToInvMessage(
            List<int> ids,
            List<int> qtys
        )
        {
            Ids = ids;
            Qtys = qtys;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Ids.Count());
            foreach (var current in Ids)
            {
                writer.WriteVarInt(current);
            }
            writer.WriteShort((short)Qtys.Count());
            foreach (var current in Qtys)
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
            var countQtys = reader.ReadShort();
            Qtys = new List<int>();
            for (short i = 0; i < countQtys; i++)
            {
                Qtys.Add(reader.ReadVarInt());
            }
        }
    }
}