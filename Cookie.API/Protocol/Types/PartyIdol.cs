using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PartyIdol : Idol
    {
        public new const ushort ProtocolId = 490;

        public override ushort TypeID => ProtocolId;

        public List<long> OwnersIds { get; set; }
        public PartyIdol() { }

        public PartyIdol( List<long> OwnersIds ){
            this.OwnersIds = OwnersIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)OwnersIds.Count);
			foreach (var x in OwnersIds)
			{
				writer.WriteVarLong(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var OwnersIdsCount = reader.ReadShort();
            OwnersIds = new List<long>();
            for (var i = 0; i < OwnersIdsCount; i++)
            {
                OwnersIds.Add(reader.ReadVarLong());
            }
        }
    }
}
