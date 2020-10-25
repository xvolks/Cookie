using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class StatedElement : NetworkType
    {
        public const short ProtocolId = 108;
        public override short TypeId { get { return ProtocolId; } }

        public int ElementId = 0;
        public short ElementCellId = 0;
        public int ElementState = 0;
        public bool OnCurrentMap = false;

        public StatedElement()
        {
        }

        public StatedElement(
            int elementId,
            short elementCellId,
            int elementState,
            bool onCurrentMap
        )
        {
            ElementId = elementId;
            ElementCellId = elementCellId;
            ElementState = elementState;
            OnCurrentMap = onCurrentMap;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(ElementId);
            writer.WriteVarShort(ElementCellId);
            writer.WriteVarInt(ElementState);
            writer.WriteBoolean(OnCurrentMap);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ElementId = reader.ReadInt();
            ElementCellId = reader.ReadVarShort();
            ElementState = reader.ReadVarInt();
            OnCurrentMap = reader.ReadBoolean();
        }
    }
}