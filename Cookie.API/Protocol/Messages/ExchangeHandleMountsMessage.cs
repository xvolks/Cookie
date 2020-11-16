using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeHandleMountsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6752;

        public override ushort MessageID => ProtocolId;

        public sbyte ActionType { get; set; }
        public List<int> RidesId { get; set; }
        public ExchangeHandleMountsMessage() { }

        public ExchangeHandleMountsMessage( sbyte ActionType, List<int> RidesId ){
            this.ActionType = ActionType;
            this.RidesId = RidesId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ActionType);
			writer.WriteShort((short)RidesId.Count);
			foreach (var x in RidesId)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionType = reader.ReadSByte();
            var RidesIdCount = reader.ReadShort();
            RidesId = new List<int>();
            for (var i = 0; i < RidesIdCount; i++)
            {
                RidesId.Add(reader.ReadVarInt());
            }
        }
    }
}
