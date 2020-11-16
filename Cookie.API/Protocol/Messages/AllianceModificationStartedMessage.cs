using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceModificationStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6444;

        public override ushort MessageID => ProtocolId;

        public bool CanChangeName { get; set; }
        public bool CanChangeTag { get; set; }
        public bool CanChangeEmblem { get; set; }
        public AllianceModificationStartedMessage() { }

        public AllianceModificationStartedMessage( bool CanChangeName, bool CanChangeTag, bool CanChangeEmblem ){
            this.CanChangeName = CanChangeName;
            this.CanChangeTag = CanChangeTag;
            this.CanChangeEmblem = CanChangeEmblem;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, CanChangeName);
			flag = BooleanByteWrapper.SetFlag(1, flag, CanChangeTag);
			flag = BooleanByteWrapper.SetFlag(2, flag, CanChangeEmblem);
			writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			CanChangeName = BooleanByteWrapper.GetFlag(flag, 0);;
			CanChangeTag = BooleanByteWrapper.GetFlag(flag, 1);;
			CanChangeEmblem = BooleanByteWrapper.GetFlag(flag, 2);;
        }
    }
}
