using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
    {
        public new const ushort ProtocolId = 6469;

        public override ushort MessageID => ProtocolId;

        public List<GameServerInformations> Servers { get; set; }
        public SelectedServerDataExtendedMessage() { }

        public SelectedServerDataExtendedMessage( List<GameServerInformations> Servers ){
            this.Servers = Servers;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Servers.Count);
			foreach (var x in Servers)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var ServersCount = reader.ReadShort();
            Servers = new List<GameServerInformations>();
            for (var i = 0; i < ServersCount; i++)
            {
                var objectToAdd = new GameServerInformations();
                objectToAdd.Deserialize(reader);
                Servers.Add(objectToAdd);
            }
        }
    }
}
