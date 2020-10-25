using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage
    {
        public new const uint ProtocolId = 6532;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> ObjectUID;

        public ExchangeObjectsRemovedMessage(): base()
        {
        }

        public ExchangeObjectsRemovedMessage(
            bool remote,
            List<int> objectUID
        ): base(
            remote
        )
        {
            ObjectUID = objectUID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)ObjectUID.Count());
            foreach (var current in ObjectUID)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countObjectUID = reader.ReadShort();
            ObjectUID = new List<int>();
            for (short i = 0; i < countObjectUID; i++)
            {
                ObjectUID.Add(reader.ReadVarInt());
            }
        }
    }
}