using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Inventory.Preset
{
    public class Preset : NetworkType
    {
        public const ushort ProtocolId = 355;

        public Preset(byte presetId, byte symbolId, bool mount, List<PresetItem> objects)
        {
            PresetId = presetId;
            SymbolId = symbolId;
            Mount = mount;
            Objects = objects;
        }

        public Preset()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte PresetId { get; set; }
        public byte SymbolId { get; set; }
        public bool Mount { get; set; }
        public List<PresetItem> Objects { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(PresetId);
            writer.WriteByte(SymbolId);
            writer.WriteBoolean(Mount);
            writer.WriteShort((short) Objects.Count);
            for (var objectsIndex = 0; objectsIndex < Objects.Count; objectsIndex++)
            {
                var objectToSend = Objects[objectsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            PresetId = reader.ReadByte();
            SymbolId = reader.ReadByte();
            Mount = reader.ReadBoolean();
            var objectsCount = reader.ReadUShort();
            Objects = new List<PresetItem>();
            for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
            {
                var objectToAdd = new PresetItem();
                objectToAdd.Deserialize(reader);
                Objects.Add(objectToAdd);
            }
        }
    }
}