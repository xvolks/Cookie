using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildModificationStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6324;

        public override ushort MessageID => ProtocolId;

        public bool CanChangeName { get; set; }
        public bool CanChangeEmblem { get; set; }
        public GuildModificationStartedMessage() { }

        public GuildModificationStartedMessage( bool CanChangeName, bool CanChangeEmblem ){
            this.CanChangeName = CanChangeName;
            this.CanChangeEmblem = CanChangeEmblem;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, CanChangeName);
			flag = BooleanByteWrapper.SetFlag(1, flag, CanChangeEmblem);
			writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			CanChangeName = BooleanByteWrapper.GetFlag(flag, 0);;
			CanChangeEmblem = BooleanByteWrapper.GetFlag(flag, 1);;
        }
    }
}
