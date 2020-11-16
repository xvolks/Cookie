using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PresetUseResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6747;

        public override ushort MessageID => ProtocolId;

        public short PresetId { get; set; }
        public sbyte Code { get; set; }
        public PresetUseResultMessage() { }

        public PresetUseResultMessage( short PresetId, sbyte Code ){
            this.PresetId = PresetId;
            this.Code = Code;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
            writer.WriteSByte(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
            Code = reader.ReadSByte();
        }
    }
}
