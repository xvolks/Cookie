using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameDataPaddockObjectListAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5992;

        public override ushort MessageID => ProtocolId;

        public List<PaddockItem> PaddockItemDescription { get; set; }
        public GameDataPaddockObjectListAddMessage() { }

        public GameDataPaddockObjectListAddMessage( List<PaddockItem> PaddockItemDescription ){
            this.PaddockItemDescription = PaddockItemDescription;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)PaddockItemDescription.Count);
			foreach (var x in PaddockItemDescription)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var PaddockItemDescriptionCount = reader.ReadShort();
            PaddockItemDescription = new List<PaddockItem>();
            for (var i = 0; i < PaddockItemDescriptionCount; i++)
            {
                var objectToAdd = new PaddockItem();
                objectToAdd.Deserialize(reader);
                PaddockItemDescription.Add(objectToAdd);
            }
        }
    }
}
