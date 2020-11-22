using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameDataPaddockObjectListAddMessage : NetworkMessage
    {
        public const uint ProtocolId = 5992;
        public override uint MessageID { get { return ProtocolId; } }

        public List<PaddockItem> PaddockItemDescription;

        public GameDataPaddockObjectListAddMessage()
        {
        }

        public GameDataPaddockObjectListAddMessage(
            List<PaddockItem> paddockItemDescription
        )
        {
            PaddockItemDescription = paddockItemDescription;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)PaddockItemDescription.Count());
            foreach (var current in PaddockItemDescription)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countPaddockItemDescription = reader.ReadShort();
            PaddockItemDescription = new List<PaddockItem>();
            for (short i = 0; i < countPaddockItemDescription; i++)
            {
                PaddockItem type = new PaddockItem();
                type.Deserialize(reader);
                PaddockItemDescription.Add(type);
            }
        }
    }
}