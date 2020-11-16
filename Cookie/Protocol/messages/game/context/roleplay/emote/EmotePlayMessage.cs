using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class EmotePlayMessage : EmotePlayAbstractMessage
    {
        public new const uint ProtocolId = 5683;
        public override uint MessageID { get { return ProtocolId; } }

        public double ActorId = 0;
        public int AccountId = 0;

        public EmotePlayMessage(): base()
        {
        }

        public EmotePlayMessage(
            byte emoteId,
            double emoteStartTime,
            double actorId,
            int accountId
        ): base(
            emoteId,
            emoteStartTime
        )
        {
            ActorId = actorId;
            AccountId = accountId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(ActorId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ActorId = reader.ReadDouble();
            AccountId = reader.ReadInt();
        }
    }
}