using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    public class ObjectItemNotInContainer : Item
    {
        public new const ushort ProtocolId = 134;

        public ObjectItemNotInContainer(ushort objectGID, List<ObjectEffect> effects, uint objectUID, uint quantity)
        {
            ObjectGID = objectGID;
            Effects = effects;
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public ObjectItemNotInContainer()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort ObjectGID { get; set; }
        public List<ObjectEffect> Effects { get; set; }
        public uint ObjectUID { get; set; }
        public uint Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGID);
            writer.WriteShort((short) Effects.Count);
            for (var effectsIndex = 0; effectsIndex < Effects.Count; effectsIndex++)
            {
                var objectToSend = Effects[effectsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarUhShort();
            var effectsCount = reader.ReadUShort();
            Effects = new List<ObjectEffect>();
            for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Effects.Add(objectToAdd);
            }
            ObjectUID = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }
    }
}