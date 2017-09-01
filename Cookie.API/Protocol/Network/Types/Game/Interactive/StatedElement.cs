using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Interactive
{
    public class StatedElement : NetworkType
    {
        public const ushort ProtocolId = 108;

        public StatedElement(int elementId, ushort elementCellId, uint elementState, bool onCurrentMap)
        {
            ElementId = elementId;
            ElementCellId = elementCellId;
            ElementState = elementState;
            OnCurrentMap = onCurrentMap;
        }

        public StatedElement()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int ElementId { get; set; }
        public ushort ElementCellId { get; set; }
        public uint ElementState { get; set; }
        public bool OnCurrentMap { get; set; }

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