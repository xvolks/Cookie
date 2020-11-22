using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LeaveDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5502;

        public override ushort MessageID => ProtocolId;

        public sbyte DialogType { get; set; }
        public LeaveDialogMessage() { }

        public LeaveDialogMessage( sbyte DialogType ){
            this.DialogType = DialogType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(DialogType);
        }

        public override void Deserialize(IDataReader reader)
        {
            DialogType = reader.ReadSByte();
        }
    }
}
