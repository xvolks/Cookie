namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Types.Game.Look;
    using Utils.IO;

    public class GameActionFightChangeLookMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5532;
        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public EntityLook EntityLook { get; set; }

        public GameActionFightChangeLookMessage(double targetId, EntityLook entityLook)
        {
            TargetId = targetId;
            EntityLook = entityLook;
        }

        public GameActionFightChangeLookMessage() { }

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
