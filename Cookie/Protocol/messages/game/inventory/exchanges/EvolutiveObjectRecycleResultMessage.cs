using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class EvolutiveObjectRecycleResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 6779;
        public override uint MessageID { get { return ProtocolId; } }

        public List<RecycledItem> RecycledItems;

        public EvolutiveObjectRecycleResultMessage()
        {
        }

        public EvolutiveObjectRecycleResultMessage(
            List<RecycledItem> recycledItems
        )
        {
            RecycledItems = recycledItems;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)RecycledItems.Count());
            foreach (var current in RecycledItems)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countRecycledItems = reader.ReadShort();
            RecycledItems = new List<RecycledItem>();
            for (short i = 0; i < countRecycledItems; i++)
            {
                RecycledItem type = new RecycledItem();
                type.Deserialize(reader);
                RecycledItems.Add(type);
            }
        }
    }
}