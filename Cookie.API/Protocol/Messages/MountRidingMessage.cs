using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountRidingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5967;

        public override ushort MessageID => ProtocolId;

        public bool IsRiding { get; set; }
        public bool IsAutopilot { get; set; }
        public MountRidingMessage() { }

        public MountRidingMessage( bool IsRiding, bool IsAutopilot ){
            this.IsRiding = IsRiding;
            this.IsAutopilot = IsAutopilot;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, IsRiding);
			flag = BooleanByteWrapper.SetFlag(1, flag, IsAutopilot);
			writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			IsRiding = BooleanByteWrapper.GetFlag(flag, 0);;
			IsAutopilot = BooleanByteWrapper.GetFlag(flag, 1);;
        }
    }
}
