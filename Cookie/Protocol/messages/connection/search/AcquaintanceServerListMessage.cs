using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AcquaintanceServerListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6142;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> Servers;

        public AcquaintanceServerListMessage()
        {
        }

        public AcquaintanceServerListMessage(
            List<short> servers
        )
        {
            Servers = servers;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Servers.Count());
            foreach (var current in Servers)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countServers = reader.ReadShort();
            Servers = new List<short>();
            for (short i = 0; i < countServers; i++)
            {
                Servers.Add(reader.ReadVarShort());
            }
        }
    }
}