using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class StorageInventoryContentMessage : InventoryContentMessage
    {
        public new const uint ProtocolId = 5646;
        public override uint MessageID { get { return ProtocolId; } }

        public StorageInventoryContentMessage(): base()
        {
        }

        public StorageInventoryContentMessage(
            List<ObjectItem> objects,
            long kamas
        ): base(
            objects,
            kamas
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}