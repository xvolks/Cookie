using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightChangeLookMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5532;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public EntityLook EntityLook_;

        public GameActionFightChangeLookMessage(): base()
        {
        }

        public GameActionFightChangeLookMessage(
            short actionId,
            double sourceId,
            double targetId,
            EntityLook entityLook_
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            EntityLook_ = entityLook_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            EntityLook_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            EntityLook_ = new EntityLook();
            EntityLook_.Deserialize(reader);
        }
    }
}