using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PaddockInstancesInformations : PaddockInformations
    {
        public new const ushort ProtocolId = 509;

        public override ushort TypeID => ProtocolId;

        public List<PaddockBuyableInformations> Paddocks { get; set; }
        public PaddockInstancesInformations() { }

        public PaddockInstancesInformations( List<PaddockBuyableInformations> Paddocks ){
            this.Paddocks = Paddocks;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Paddocks.Count);
			foreach (var x in Paddocks)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var PaddocksCount = reader.ReadShort();
            Paddocks = new List<PaddockBuyableInformations>();
            for (var i = 0; i < PaddocksCount; i++)
            {
                PaddockBuyableInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Paddocks.Add(objectToAdd);
            }
        }
    }
}
