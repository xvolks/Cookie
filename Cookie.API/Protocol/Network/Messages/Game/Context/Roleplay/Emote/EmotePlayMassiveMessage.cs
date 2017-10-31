namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    using System.Collections.Generic;
    using Utils.IO;

    public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
    {
        public new const ushort ProtocolId = 5691;
        public override ushort MessageID => ProtocolId;
        public List<double> ActorIds { get; set; }

        public EmotePlayMassiveMessage(List<double> actorIds)
        {
            ActorIds = actorIds;
        }

        public EmotePlayMassiveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)ActorIds.Count);
            for (var actorIdsIndex = 0; actorIdsIndex < ActorIds.Count; actorIdsIndex++)
            {
                writer.WriteDouble(ActorIds[actorIdsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var actorIdsCount = reader.ReadUShort();
            ActorIds = new List<double>();
            for (var actorIdsIndex = 0; actorIdsIndex < actorIdsCount; actorIdsIndex++)
            {
                ActorIds.Add(reader.ReadDouble());
            }
        }

    }
}
