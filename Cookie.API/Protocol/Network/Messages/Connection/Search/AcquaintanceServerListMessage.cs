using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection.Search
{
    public class AcquaintanceServerListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6142;

        public AcquaintanceServerListMessage(List<ushort> servers)
        {
            Servers = servers;
        }

        public AcquaintanceServerListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> Servers { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Servers.Count);
            for (var serversIndex = 0; serversIndex < Servers.Count; serversIndex++)
                writer.WriteVarUhShort(Servers[serversIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var serversCount = reader.ReadUShort();
            Servers = new List<ushort>();
            for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
                Servers.Add(reader.ReadVarUhShort());
        }
    }
}