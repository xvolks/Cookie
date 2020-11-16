using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PresetSaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6761;

        public override ushort MessageID => ProtocolId;

        public short PresetId { get; set; }
        public sbyte SymbolId { get; set; }
        public bool UpdateData { get; set; }
        public PresetSaveRequestMessage() { }

        public PresetSaveRequestMessage( short PresetId, sbyte SymbolId, bool UpdateData ){
            this.PresetId = PresetId;
            this.SymbolId = SymbolId;
            this.UpdateData = UpdateData;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PresetId);
            writer.WriteSByte(SymbolId);
            writer.WriteBoolean(UpdateData);
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadShort();
            SymbolId = reader.ReadSByte();
            UpdateData = reader.ReadBoolean();
        }
    }
}
