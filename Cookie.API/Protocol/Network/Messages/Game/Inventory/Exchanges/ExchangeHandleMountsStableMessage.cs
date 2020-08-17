using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeHandleMountsStableMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6562;

        public ExchangeHandleMountsStableMessage(sbyte actionType, List<uint> ridesId)
        {
            ActionType = actionType;
            RidesId = ridesId;
        }

        public ExchangeHandleMountsStableMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte ActionType { get; set; }
        public List<uint> RidesId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ActionType);
            writer.WriteShort((short) RidesId.Count);
            for (var ridesIdIndex = 0; ridesIdIndex < RidesId.Count; ridesIdIndex++)
                writer.WriteVarUhInt(RidesId[ridesIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionType = reader.ReadSByte();
            var ridesIdCount = reader.ReadUShort();
            RidesId = new List<uint>();
            for (var ridesIdIndex = 0; ridesIdIndex < ridesIdCount; ridesIdIndex++)
                RidesId.Add(reader.ReadVarUhInt());
        }
    }
}