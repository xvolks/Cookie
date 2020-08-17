using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    public class ObjectItemToSellInBid : ObjectItemToSell
    {
        public new const ushort ProtocolId = 164;

        public ObjectItemToSellInBid(int unsoldDelay)
        {
            UnsoldDelay = unsoldDelay;
        }

        public ObjectItemToSellInBid()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int UnsoldDelay { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(UnsoldDelay);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            UnsoldDelay = reader.ReadInt();
        }
    }
}