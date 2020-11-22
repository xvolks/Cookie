using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildGetInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5550;

        public override ushort MessageID => ProtocolId;

        public sbyte InfoType { get; set; }
        public GuildGetInformationsMessage() { }

        public GuildGetInformationsMessage( sbyte InfoType ){
            this.InfoType = InfoType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(InfoType);
        }

        public override void Deserialize(IDataReader reader)
        {
            InfoType = reader.ReadSByte();
        }
    }
}
