using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class GameRolePlayShowActorWithEventMessage : GameRolePlayShowActorMessage
    {
        public new const ushort ProtocolId = 6407;

        public GameRolePlayShowActorWithEventMessage(byte actorEventId)
        {
            ActorEventId = actorEventId;
        }

        public GameRolePlayShowActorWithEventMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte ActorEventId { get; set; }

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