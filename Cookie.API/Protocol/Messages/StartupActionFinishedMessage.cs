using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StartupActionFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1304;

        public override ushort MessageID => ProtocolId;

        public bool Success { get; set; }
        public bool AutomaticAction { get; set; }
        public int ActionId { get; set; }
        public StartupActionFinishedMessage() { }

        public StartupActionFinishedMessage( bool Success, bool AutomaticAction, int ActionId ){
            this.Success = Success;
            this.AutomaticAction = AutomaticAction;
            this.ActionId = ActionId;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Success);
			flag = BooleanByteWrapper.SetFlag(1, flag, AutomaticAction);
			writer.WriteByte(flag);
            writer.WriteInt(ActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			Success = BooleanByteWrapper.GetFlag(flag, 0);;
			AutomaticAction = BooleanByteWrapper.GetFlag(flag, 1);;
            ActionId = reader.ReadInt();
        }
    }
}
