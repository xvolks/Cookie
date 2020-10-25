using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItemMinimalInformation : Item
    {
        public new const short ProtocolId = 124;
        public override short TypeId { get { return ProtocolId; } }

        public short ObjectGID = 0;
        public List<ObjectEffect> Effects;

        public ObjectItemMinimalInformation(): base()
        {
        }

        public ObjectItemMinimalInformation(
            short objectGID,
            List<ObjectEffect> effects
        ): base()
        {
            ObjectGID = objectGID;
            Effects = effects;
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
        }
    }
}