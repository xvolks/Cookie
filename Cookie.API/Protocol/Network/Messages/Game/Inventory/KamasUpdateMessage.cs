using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory
{
    public class KamasUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5537;

        public KamasUpdateMessage(ulong kamasTotal)
        {
            KamasTotal = kamasTotal;
        }

        public KamasUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong KamasTotal { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(KamasTotal);
        }

        public override void Deserialize(IDataReader reader)
        {
            KamasTotal = reader.ReadVarUhLong();
        }
    }
}