using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EntitiesInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6775;

        public override ushort MessageID => ProtocolId;

        public List<EntityInformation> Entities { get; set; }
        public EntitiesInformationMessage() { }

        public EntitiesInformationMessage( List<EntityInformation> Entities ){
            this.Entities = Entities;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Entities.Count);
			foreach (var x in Entities)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var EntitiesCount = reader.ReadShort();
            Entities = new List<EntityInformation>();
            for (var i = 0; i < EntitiesCount; i++)
            {
                var objectToAdd = new EntityInformation();
                objectToAdd.Deserialize(reader);
                Entities.Add(objectToAdd);
            }
        }
    }
}
