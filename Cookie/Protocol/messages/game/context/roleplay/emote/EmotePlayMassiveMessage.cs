using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
    {
        public new const uint ProtocolId = 5691;
        public override uint MessageID { get { return ProtocolId; } }

        public List<double> ActorIds;

        public EmotePlayMassiveMessage(): base()
        {
        }

        public EmotePlayMassiveMessage(
            byte emoteId,
            double emoteStartTime,
            List<double> actorIds
        ): base(
            emoteId,
            emoteStartTime
        )
        {
            ActorIds = actorIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)ActorIds.Count());
            foreach (var current in ActorIds)
            {
                writer.WriteDouble(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countActorIds = reader.ReadShort();
            ActorIds = new List<double>();
            for (short i = 0; i < countActorIds; i++)
            {
                ActorIds.Add(reader.ReadDouble());
            }
        }
    }
}