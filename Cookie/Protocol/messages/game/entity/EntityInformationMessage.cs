using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EntityInformationMessage : NetworkMessage
    {
        public const uint ProtocolId = 6771;
        public override uint MessageID { get { return ProtocolId; } }

        public EntityInformation Entity;

        public EntityInformationMessage()
        {
        }

        public EntityInformationMessage(
            EntityInformation entity
        )
        {
            Entity = entity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Entity.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Entity = new EntityInformation();
            Entity.Deserialize(reader);
        }
    }
}