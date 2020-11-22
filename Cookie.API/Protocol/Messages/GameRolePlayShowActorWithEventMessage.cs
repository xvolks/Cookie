using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayShowActorWithEventMessage : GameRolePlayShowActorMessage
    {
        public new const ushort ProtocolId = 6407;

        public override ushort MessageID => ProtocolId;

        public sbyte ActorEventId { get; set; }
        public GameRolePlayShowActorWithEventMessage() { }

        public GameRolePlayShowActorWithEventMessage( sbyte ActorEventId ){
            this.ActorEventId = ActorEventId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(ActorEventId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ActorEventId = reader.ReadSByte();
        }
    }
}
