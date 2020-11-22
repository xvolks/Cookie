using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PresetDeleteRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6755;

        public override ushort MessageID => ProtocolId;

        public short PresetId { get; set; }
        public PresetDeleteRequestMessage() { }

        public PresetDeleteRequestMessage( short PresetId ){
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
