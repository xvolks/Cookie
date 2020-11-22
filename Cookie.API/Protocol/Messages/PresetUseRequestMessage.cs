using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PresetUseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6759;

        public override ushort MessageID => ProtocolId;

        public short PresetId { get; set; }
        public PresetUseRequestMessage() { }

        public PresetUseRequestMessage( short PresetId ){
            this.PresetId = PresetId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
        }
    }
}
