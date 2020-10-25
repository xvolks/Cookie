using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
    {
        public new const uint ProtocolId = 6469;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GameServerInformations> Servers;

        public SelectedServerDataExtendedMessage(): base()
        {
        }

        public SelectedServerDataExtendedMessage(
            short serverId,
            string address,
            List<int> ports,
            bool canCreateNewCharacter,
            List<byte> ticket,
            List<GameServerInformations> servers
        ): base(
            serverId,
            address,
            ports,
            canCreateNewCharacter,
            ticket
        )
        {
            Servers = servers;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Servers.Count());
            foreach (var current in Servers)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countServers = reader.ReadShort();
            Servers = new List<GameServerInformations>();
            for (short i = 0; i < countServers; i++)
            {
                GameServerInformations type = new GameServerInformations();
                type.Deserialize(reader);
                Servers.Add(type);
            }
        }
    }
}