using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMountsStableRemoveMessage : NetworkMessage
    {
        public const uint ProtocolId = 6556;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> MountsId;

        public ExchangeMountsStableRemoveMessage()
        {
        }

        public ExchangeMountsStableRemoveMessage(
            List<int> mountsId
        )
        {
            MountsId = mountsId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)MountsId.Count());
            foreach (var current in MountsId)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countMountsId = reader.ReadShort();
            MountsId = new List<int>();
            for (short i = 0; i < countMountsId; i++)
            {
                MountsId.Add(reader.ReadVarInt());
            }
        }
    }
}