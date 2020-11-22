using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChangeThemeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6639;

        public override ushort MessageID => ProtocolId;

        public sbyte Theme { get; set; }
        public ChangeThemeRequestMessage() { }

        public ChangeThemeRequestMessage( sbyte Theme ){
            this.Theme = Theme;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Theme);
        }

        public override void Deserialize(IDataReader reader)
        {
            Theme = reader.ReadSByte();
        }
    }
}
