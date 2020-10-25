using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ServersListMessage : NetworkMessage
    {
        public const uint ProtocolId = 30;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GameServerInformations> Servers;
        public short AlreadyConnectedToServerId = 0;
        public bool CanCreateNewCharacter = false;

        public ServersListMessage()
        {
        }

        public ServersListMessage(
            List<GameServerInformations> servers,
            short alreadyConnectedToServerId,
            bool canCreateNewCharacter
        )
        {
            Servers = servers;
            AlreadyConnectedToServerId = alreadyConnectedToServerId;
            CanCreateNewCharacter = canCreateNewCharacter;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Servers.Count());
            foreach (var current in Servers)
            {
                current.Serialize(writer);
            }
            writer.WriteVarShort(AlreadyConnectedToServerId);
            writer.WriteBoolean(CanCreateNewCharacter);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countServers = reader.ReadShort();
            Servers = new List<GameServerInformations>();
            for (short i = 0; i < countServers; i++)
            {
                GameServerInformations type = new GameServerInformations();
                type.Deserialize(reader);
                Servers.Add(type);
            }
            AlreadyConnectedToServerId = reader.ReadVarShort();
            CanCreateNewCharacter = reader.ReadBoolean();
        }
    }
}