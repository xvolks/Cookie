using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class StatedElement : NetworkType
    {
        public const ushort ProtocolId = 108;

        public override ushort TypeID => ProtocolId;

        public int ElementId { get; set; }
        public ushort ElementCellId { get; set; }
        public uint ElementState { get; set; }
        public bool OnCurrentMap { get; set; }
        public StatedElement() { }

        public StatedElement( int ElementId, ushort ElementCellId, uint ElementState, bool OnCurrentMap ){
            this.ElementId = ElementId;
            this.ElementCellId = ElementCellId;
            this.ElementState = ElementState;
            this.OnCurrentMap = OnCurrentMap;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ElementId);
            writer.WriteVarUhShort(ElementCellId);
            writer.WriteVarUhInt(ElementState);
            writer.WriteBoolean(OnCurrentMap);
        }

        public override void Deserialize(IDataReader reader)
        {
            ElementId = reader.ReadInt();
            ElementCellId = reader.ReadVarUhShort();
            ElementState = reader.ReadVarUhInt();
            OnCurrentMap = reader.ReadBoolean();
        }
    }
}
