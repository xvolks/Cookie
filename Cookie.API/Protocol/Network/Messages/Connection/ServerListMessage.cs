using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Connection;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class ServerListMessage : NetworkMessage
    {
        public const uint ProtocolId = 30;
        public ushort AlreadyConnectedToServerId;
        public bool CanCreateNewCharacter;

        public List<GameServerInformations> Servers;

        public ServerListMessage()
        {
        }

        public ServerListMessage(List<GameServerInformations> servers, ushort alreadyConnectedToServerId,
            bool canCreateNewCharacter)
        {
            Servers = servers;
            AlreadyConnectedToServerId = alreadyConnectedToServerId;
            CanCreateNewCharacter = canCreateNewCharacter;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Servers.Count);
            for (var serversIndex = 0; serversIndex < Servers.Count; serversIndex = serversIndex + 1)
            {
                var objectToSend = Servers[serversIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteVarShort((short) AlreadyConnectedToServerId);
            writer.WriteBoolean(CanCreateNewCharacter);
        }

        public override void Deserialize(IDataReader reader)
        {
            int serversCount = reader.ReadUShort();
            int serversIndex;
            Servers = new List<GameServerInformations>();
            for (serversIndex = 0; serversIndex < serversCount; serversIndex = serversIndex + 1)
            {
                var objectToAdd = new GameServerInformations();
                objectToAdd.Deserialize(reader);
                Servers.Add(objectToAdd);
            }
            AlreadyConnectedToServerId = reader.ReadVarUhShort();
            CanCreateNewCharacter = reader.ReadBoolean();
        }
    }
}