using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItem : Item
    {
        public new const short ProtocolId = 37;
        public override short TypeId { get { return ProtocolId; } }

        public short Position = 63;
        public short ObjectGID = 0;
        public List<ObjectEffect> Effects;
        public int ObjectUID = 0;
        public int Quantity = 0;

        public ObjectItem(): base()
        {
        }

        public ObjectItem(
            short position,
            short objectGID,
            List<ObjectEffect> effects,
            int objectUID,
            int quantity
        ): base()
        {
            Position = position;
            ObjectGID = objectGID;
            Effects = effects;
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Position);
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
            base.Deserialize(reader); // empty struct
            Position = reader.ReadShort();
            ObjectGID = Convert.ToInt16(reader.ReadVarUhShort());
            var countEffects = reader.ReadShort();
            Effects = new List<ObjectEffect>();
            for (short i = 0; i < countEffects; i++)
            {
                var effectstypeId = reader.ReadShort();
                ObjectEffect type = ProtocolTypeManager.GetInstance<ObjectEffect>(effectstypeId);
                type.Deserialize(reader);
                Effects.Add(type);
            }
            ObjectUID = reader.ReadVarInt();
            Quantity = reader.ReadVarInt();
        }
    }
}