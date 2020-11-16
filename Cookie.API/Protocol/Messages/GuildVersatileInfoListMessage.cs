using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildVersatileInfoListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6435;

        public override ushort MessageID => ProtocolId;

        public List<GuildVersatileInformations> Guilds { get; set; }
        public GuildVersatileInfoListMessage() { }

        public GuildVersatileInfoListMessage( List<GuildVersatileInformations> Guilds ){
            this.Guilds = Guilds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Guilds.Count);
			foreach (var x in Guilds)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var GuildsCount = reader.ReadShort();
            Guilds = new List<GuildVersatileInformations>();
            for (var i = 0; i < GuildsCount; i++)
            {
                GuildVersatileInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Guilds.Add(objectToAdd);
            }
        }
    }
}
