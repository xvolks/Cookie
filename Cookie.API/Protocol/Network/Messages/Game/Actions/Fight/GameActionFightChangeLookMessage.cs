using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightChangeLookMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5532;

        public GameActionFightChangeLookMessage(double targetId, EntityLook entityLook)
        {
            TargetId = targetId;
            EntityLook = entityLook;
        }

        public GameActionFightChangeLookMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public EntityLook EntityLook { get; set; }

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