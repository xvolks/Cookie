using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeObjectTransfertListToInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6039;

        public ExchangeObjectTransfertListToInvMessage(List<uint> ids)
        {
            Ids = ids;
        }

        public ExchangeObjectTransfertListToInvMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<uint> Ids { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Ids.Count);
            for (var idsIndex = 0; idsIndex < Ids.Count; idsIndex++)
                writer.WriteVarUhInt(Ids[idsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var idsCount = reader.ReadUShort();
            Ids = new List<uint>();
            for (var idsIndex = 0; idsIndex < idsCount; idsIndex++)
                Ids.Add(reader.ReadVarUhInt());
        }
    }
}