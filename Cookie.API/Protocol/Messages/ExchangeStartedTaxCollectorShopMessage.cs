using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartedTaxCollectorShopMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6664;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItem> Objects { get; set; }
        public ulong Kamas { get; set; }
        public ExchangeStartedTaxCollectorShopMessage() { }

        public ExchangeStartedTaxCollectorShopMessage( List<ObjectItem> Objects, ulong Kamas ){
            this.Objects = Objects;
            this.Kamas = Kamas;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Objects.Count);
			foreach (var x in Objects)
			{
				x.Serialize(writer);
			}
            writer.WriteVarUhLong(Kamas);
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectsCount = reader.ReadShort();
            Objects = new List<ObjectItem>();
            for (var i = 0; i < ObjectsCount; i++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                Objects.Add(objectToAdd);
            }
            Kamas = reader.ReadVarUhLong();
        }
    }
}
