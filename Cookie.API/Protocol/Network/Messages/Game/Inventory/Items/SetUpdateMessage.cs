using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class SetUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5503;

        public SetUpdateMessage(ushort setId, List<ushort> setObjects, List<ObjectEffect> setEffects)
        {
            SetId = setId;
            SetObjects = setObjects;
            SetEffects = setEffects;
        }

        public SetUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SetId { get; set; }
        public List<ushort> SetObjects { get; set; }
        public List<ObjectEffect> SetEffects { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SetId);
            writer.WriteShort((short) SetObjects.Count);
            for (var setObjectsIndex = 0; setObjectsIndex < SetObjects.Count; setObjectsIndex++)
                writer.WriteVarUhShort(SetObjects[setObjectsIndex]);
            writer.WriteShort((short) SetEffects.Count);
            for (var setEffectsIndex = 0; setEffectsIndex < SetEffects.Count; setEffectsIndex++)
            {
                var objectToSend = SetEffects[setEffectsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            SetId = reader.ReadVarUhShort();
            var setObjectsCount = reader.ReadUShort();
            SetObjects = new List<ushort>();
            for (var setObjectsIndex = 0; setObjectsIndex < setObjectsCount; setObjectsIndex++)
                SetObjects.Add(reader.ReadVarUhShort());
            var setEffectsCount = reader.ReadUShort();
            SetEffects = new List<ObjectEffect>();
            for (var setEffectsIndex = 0; setEffectsIndex < setEffectsCount; setEffectsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                SetEffects.Add(objectToAdd);
            }
        }
    }
}