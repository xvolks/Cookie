namespace Cookie.API.Protocol.Network.Types.Game.Paddock
{
    using System.Collections.Generic;
    using Utils.IO;

    public class PaddockInstancesInformations : PaddockInformations
    {
        public new const ushort ProtocolId = 509;
        public override ushort TypeID => ProtocolId;
        public List<PaddockBuyableInformations> Paddocks { get; set; }

        public PaddockInstancesInformations(List<PaddockBuyableInformations> paddocks)
        {
            Paddocks = paddocks;
        }

        public PaddockInstancesInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Paddocks.Count);
            for (var paddocksIndex = 0; paddocksIndex < Paddocks.Count; paddocksIndex++)
            {
                var objectToSend = Paddocks[paddocksIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var paddocksCount = reader.ReadUShort();
            Paddocks = new List<PaddockBuyableInformations>();
            for (var paddocksIndex = 0; paddocksIndex < paddocksCount; paddocksIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<PaddockBuyableInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Paddocks.Add(objectToAdd);
            }
        }

    }
}
