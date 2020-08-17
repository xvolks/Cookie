namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class GameRolePlayShowActorWithEventMessage : GameRolePlayShowActorMessage
    {
        public new const ushort ProtocolId = 6407;
        public override ushort MessageID => ProtocolId;
        public byte ActorEventId { get; set; }

        public GameRolePlayShowActorWithEventMessage(byte actorEventId)
        {
            ActorEventId = actorEventId;
        }

        public GameRolePlayShowActorWithEventMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(ActorEventId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ActorEventId = reader.ReadByte();
        }

    }
}
