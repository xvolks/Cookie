using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ServersListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 30;

        public override ushort MessageID => ProtocolId;

        public List<GameServerInformations> Servers { get; set; }
        public ushort AlreadyConnectedToServerId { get; set; }
        public bool CanCreateNewCharacter { get; set; }
        public ServersListMessage() { }

        public ServersListMessage( List<GameServerInformations> Servers, ushort AlreadyConnectedToServerId, bool CanCreateNewCharacter ){
            this.Servers = Servers;
            this.AlreadyConnectedToServerId = AlreadyConnectedToServerId;
            this.CanCreateNewCharacter = CanCreateNewCharacter;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Servers.Count);
			foreach (var x in Servers)
			{
				x.Serialize(writer);
			}
            writer.WriteVarUhShort(AlreadyConnectedToServerId);
            writer.WriteBoolean(CanCreateNewCharacter);
        }

        public override void Deserialize(IDataReader reader)
        {
            var ServersCount = reader.ReadShort();
            Servers = new List<GameServerInformations>();
            for (var i = 0; i < ServersCount; i++)
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
