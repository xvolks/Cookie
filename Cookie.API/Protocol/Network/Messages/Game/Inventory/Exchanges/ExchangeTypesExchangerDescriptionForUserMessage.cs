using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeTypesExchangerDescriptionForUserMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5765;

        public ExchangeTypesExchangerDescriptionForUserMessage(List<uint> typeDescription)
        {
            TypeDescription = typeDescription;
        }

        public ExchangeTypesExchangerDescriptionForUserMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<uint> TypeDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) TypeDescription.Count);
            for (var typeDescriptionIndex = 0; typeDescriptionIndex < TypeDescription.Count; typeDescriptionIndex++)
                writer.WriteVarUhInt(TypeDescription[typeDescriptionIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var typeDescriptionCount = reader.ReadUShort();
            TypeDescription = new List<uint>();
            for (var typeDescriptionIndex = 0; typeDescriptionIndex < typeDescriptionCount; typeDescriptionIndex++)
                TypeDescription.Add(reader.ReadVarUhInt());
        }
    }
}