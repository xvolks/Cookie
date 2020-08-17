using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeObjectTransfertListWithQuantityToInvMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6470;

        public ExchangeObjectTransfertListWithQuantityToInvMessage(List<uint> ids, List<uint> qtys)
        {
            Ids = ids;
            Qtys = qtys;
        }

        public ExchangeObjectTransfertListWithQuantityToInvMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<uint> Ids { get; set; }
        public List<uint> Qtys { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Ids.Count);
            for (var idsIndex = 0; idsIndex < Ids.Count; idsIndex++)
                writer.WriteVarUhInt(Ids[idsIndex]);
            writer.WriteShort((short) Qtys.Count);
            for (var qtysIndex = 0; qtysIndex < Qtys.Count; qtysIndex++)
                writer.WriteVarUhInt(Qtys[qtysIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var idsCount = reader.ReadUShort();
            Ids = new List<uint>();
            for (var idsIndex = 0; idsIndex < idsCount; idsIndex++)
                Ids.Add(reader.ReadVarUhInt());
            var qtysCount = reader.ReadUShort();
            Qtys = new List<uint>();
            for (var qtysIndex = 0; qtysIndex < qtysCount; qtysIndex++)
                Qtys.Add(reader.ReadVarUhInt());
        }
    }
}