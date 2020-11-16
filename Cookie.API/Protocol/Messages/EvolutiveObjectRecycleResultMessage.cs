using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EvolutiveObjectRecycleResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6779;

        public override ushort MessageID => ProtocolId;

        public List<RecycledItem> RecycledItems { get; set; }
        public EvolutiveObjectRecycleResultMessage() { }

        public EvolutiveObjectRecycleResultMessage( List<RecycledItem> RecycledItems ){
            this.RecycledItems = RecycledItems;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)RecycledItems.Count);
			foreach (var x in RecycledItems)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var RecycledItemsCount = reader.ReadShort();
            RecycledItems = new List<RecycledItem>();
            for (var i = 0; i < RecycledItemsCount; i++)
            {
                var objectToAdd = new RecycledItem();
                objectToAdd.Deserialize(reader);
                RecycledItems.Add(objectToAdd);
            }
        }
    }
}
