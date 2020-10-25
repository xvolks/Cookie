using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class EntitiesInformationMessage : NetworkMessage
    {
        public const uint ProtocolId = 6775;
        public override uint MessageID { get { return ProtocolId; } }

        public List<EntityInformation> Entities;

        public EntitiesInformationMessage()
        {
        }

        public EntitiesInformationMessage(
            List<EntityInformation> entities
        )
        {
            Entities = entities;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Entities.Count());
            foreach (var current in Entities)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countEntities = reader.ReadShort();
            Entities = new List<EntityInformation>();
            for (short i = 0; i < countEntities; i++)
            {
                EntityInformation type = new EntityInformation();
                type.Deserialize(reader);
                Entities.Add(type);
            }
        }
    }
}