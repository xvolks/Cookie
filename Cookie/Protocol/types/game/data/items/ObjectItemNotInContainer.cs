using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItemNotInContainer : Item
    {
        public new const short ProtocolId = 134;
        public override short TypeId { get { return ProtocolId; } }

        public short ObjectGID = 0;
        public List<ObjectEffect> Effects;
        public int ObjectUID = 0;
        public int Quantity = 0;

        public ObjectItemNotInContainer(): base()
        {
        }

        public ObjectItemNotInContainer(
            short objectGID,
            List<ObjectEffect> effects,
            int objectUID,
            int quantity
        ): base()
        {
            ObjectGID = objectGID;
            Effects = effects;
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(ObjectGID);
            writer.WriteShort((short)Effects.Count());
            foreach (var current in Effects)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteVarInt(ObjectUID);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarShort();
            var countEffects = reader.ReadShort();
            Effects = new List<ObjectEffect>();
            for (short i = 0; i < countEffects; i++)
            {
                var effectstypeId = reader.ReadShort();
                ObjectEffect type = new ObjectEffect();
                type.Deserialize(reader);
                Effects.Add(type);
            }
            ObjectUID = reader.ReadVarInt();
            Quantity = reader.ReadVarInt();
        }
    }
}