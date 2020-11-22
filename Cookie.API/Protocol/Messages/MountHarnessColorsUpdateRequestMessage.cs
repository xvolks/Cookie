using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountHarnessColorsUpdateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6697;

        public override ushort MessageID => ProtocolId;

        public bool UseHarnessColors { get; set; }
        public MountHarnessColorsUpdateRequestMessage() { }

        public MountHarnessColorsUpdateRequestMessage( bool UseHarnessColors ){
            this.UseHarnessColors = UseHarnessColors;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(UseHarnessColors);
        }

        public override void Deserialize(IDataReader reader)
        {
            UseHarnessColors = reader.ReadBoolean();
        }
    }
}
