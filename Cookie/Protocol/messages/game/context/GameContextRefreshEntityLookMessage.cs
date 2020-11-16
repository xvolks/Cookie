using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextRefreshEntityLookMessage : NetworkMessage
    {
        public const uint ProtocolId = 5637;
        public override uint MessageID { get { return ProtocolId; } }

        public double Id_ = 0;
        public EntityLook Look;

        public GameContextRefreshEntityLookMessage()
        {
        }

        public GameContextRefreshEntityLookMessage(
            double id_,
            EntityLook look
        )
        {
            Id_ = id_;
            Look = look;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Id_);
            Look.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadDouble();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}