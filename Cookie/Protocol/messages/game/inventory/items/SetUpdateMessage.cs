using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class SetUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5503;
        public override uint MessageID { get { return ProtocolId; } }

        public short SetId = 0;
        public List<short> SetObjects;
        public List<ObjectEffect> SetEffects;

        public SetUpdateMessage()
        {
        }

        public SetUpdateMessage(
            short setId,
            List<short> setObjects,
            List<ObjectEffect> setEffects
        )
        {
            SetId = setId;
            SetObjects = setObjects;
            SetEffects = setEffects;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SetId);
            writer.WriteShort((short)SetObjects.Count());
            foreach (var current in SetObjects)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)SetEffects.Count());
            foreach (var current in SetEffects)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SetId = reader.ReadVarShort();
            var countSetObjects = reader.ReadShort();
            SetObjects = new List<short>();
            for (short i = 0; i < countSetObjects; i++)
            {
                SetObjects.Add(reader.ReadVarShort());
            }
            var countSetEffects = reader.ReadShort();
            SetEffects = new List<ObjectEffect>();
            for (short i = 0; i < countSetEffects; i++)
            {
                var setEffectstypeId = reader.ReadShort();
                ObjectEffect type = new ObjectEffect();
                type.Deserialize(reader);
                SetEffects.Add(type);
            }
        }
    }
}