using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareWonListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6682;

        public override ushort MessageID => ProtocolId;

        public List<double> DareId { get; set; }
        public DareWonListMessage() { }

        public DareWonListMessage( List<double> DareId ){
            this.DareId = DareId;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)DareId.Count);
			foreach (var x in DareId)
			{
				writer.WriteDouble(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var DareIdCount = reader.ReadShort();
            DareId = new List<double>();
            for (var i = 0; i < DareIdCount; i++)
            {
                DareId.Add(reader.ReadDouble());
            }
        }
    }
}
