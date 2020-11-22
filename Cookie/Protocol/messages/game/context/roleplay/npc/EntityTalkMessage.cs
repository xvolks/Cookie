using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class EntityTalkMessage : NetworkMessage
    {
        public const uint ProtocolId = 6110;
        public override uint MessageID { get { return ProtocolId; } }

        public double EntityId = 0;
        public short TextId = 0;
        public List<string> Parameters;

        public EntityTalkMessage()
        {
        }

        public EntityTalkMessage(
            double entityId,
            short textId,
            List<string> parameters
        )
        {
            EntityId = entityId;
            TextId = textId;
            Parameters = parameters;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(EntityId);
            writer.WriteVarShort(TextId);
            writer.WriteShort((short)Parameters.Count());
            foreach (var current in Parameters)
            {
                writer.WriteUTF(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            EntityId = reader.ReadDouble();
            TextId = reader.ReadVarShort();
            var countParameters = reader.ReadShort();
            Parameters = new List<string>();
            for (short i = 0; i < countParameters; i++)
            {
                Parameters.Add(reader.ReadUTF());
            }
        }
    }
}