using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameContextRefreshEntityLookMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5637;

        public override ushort MessageID => ProtocolId;

        public double Id { get; set; }
        public EntityLook Look { get; set; }
        public GameContextRefreshEntityLookMessage() { }

        public GameContextRefreshEntityLookMessage( double Id, EntityLook Look ){
            this.Id = Id;
            this.Look = Look;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Id);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadDouble();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}
