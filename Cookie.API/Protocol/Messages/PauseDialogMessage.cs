using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PauseDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6012;

        public override ushort MessageID => ProtocolId;

        public sbyte DialogType { get; set; }
        public PauseDialogMessage() { }

        public PauseDialogMessage( sbyte DialogType ){
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
