using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayShowActorWithEventMessage : GameRolePlayShowActorMessage
    {
        public new const uint ProtocolId = 6407;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ActorEventId = 0;

        public GameRolePlayShowActorWithEventMessage(): base()
        {
        }

        public GameRolePlayShowActorWithEventMessage(
            GameRolePlayActorInformations informations,
            byte actorEventId
        ): base(
            informations
        )
        {
            ActorEventId = actorEventId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(ActorEventId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ActorEventId = reader.ReadByte();
        }
    }
}