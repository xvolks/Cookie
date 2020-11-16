using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightChangeLookMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5532;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public EntityLook EntityLook { get; set; }
        public GameActionFightChangeLookMessage() { }

        public GameActionFightChangeLookMessage( double TargetId, EntityLook EntityLook ){
            this.TargetId = TargetId;
            this.EntityLook = EntityLook;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            EntityLook.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            EntityLook = new EntityLook();
            EntityLook.Deserialize(reader);
        }
    }
}
