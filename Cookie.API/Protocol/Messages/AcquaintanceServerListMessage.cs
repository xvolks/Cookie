using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AcquaintanceServerListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6142;

        public override ushort MessageID => ProtocolId;

        public List<short> Servers { get; set; }
        public AcquaintanceServerListMessage() { }

        public AcquaintanceServerListMessage( List<short> Servers ){
            this.Servers = Servers;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Servers.Count);
			foreach (var x in Servers)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ServersCount = reader.ReadShort();
            Servers = new List<short>();
            for (var i = 0; i < ServersCount; i++)
            {
                Servers.Add(reader.ReadVarShort());
            }
        }
    }
}
