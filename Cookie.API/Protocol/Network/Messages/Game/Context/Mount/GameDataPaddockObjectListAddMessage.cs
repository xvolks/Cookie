using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Paddock;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class GameDataPaddockObjectListAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5992;

        public GameDataPaddockObjectListAddMessage(List<PaddockItem> paddockItemDescription)
        {
            PaddockItemDescription = paddockItemDescription;
        }

        public GameDataPaddockObjectListAddMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<PaddockItem> PaddockItemDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) PaddockItemDescription.Count);
            for (var paddockItemDescriptionIndex = 0;
                paddockItemDescriptionIndex < PaddockItemDescription.Count;
                paddockItemDescriptionIndex++)
            {
                var objectToSend = PaddockItemDescription[paddockItemDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var paddockItemDescriptionCount = reader.ReadUShort();
            PaddockItemDescription = new List<PaddockItem>();
            for (var paddockItemDescriptionIndex = 0;
                paddockItemDescriptionIndex < paddockItemDescriptionCount;
                paddockItemDescriptionIndex++)
            {
                var objectToAdd = new PaddockItem();
                objectToAdd.Deserialize(reader);
                PaddockItemDescription.Add(objectToAdd);
            }
        }
    }
}