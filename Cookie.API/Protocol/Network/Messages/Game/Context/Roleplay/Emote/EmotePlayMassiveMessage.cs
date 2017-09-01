using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
    {
        public new const ushort ProtocolId = 5691;

        public EmotePlayMassiveMessage(List<double> actorIds)
        {
            ActorIds = actorIds;
        }

        public EmotePlayMassiveMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<double> ActorIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) ActorIds.Count);
            for (var actorIdsIndex = 0; actorIdsIndex < ActorIds.Count; actorIdsIndex++)
                writer.WriteDouble(ActorIds[actorIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var actorIdsCount = reader.ReadUShort();
            ActorIds = new List<double>();
            for (var actorIdsIndex = 0; actorIdsIndex < actorIdsCount; actorIdsIndex++)
                ActorIds.Add(reader.ReadDouble());
        }
    }
}