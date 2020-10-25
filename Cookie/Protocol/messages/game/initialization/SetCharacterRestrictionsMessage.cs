using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SetCharacterRestrictionsMessage : NetworkMessage
    {
        public const uint ProtocolId = 170;
        public override uint MessageID { get { return ProtocolId; } }

        public double ActorId = 0;
        public ActorRestrictionsInformations Restrictions;

        public SetCharacterRestrictionsMessage()
        {
        }

        public SetCharacterRestrictionsMessage(
            double actorId,
            ActorRestrictionsInformations restrictions
        )
        {
            ActorId = actorId;
            Restrictions = restrictions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(ActorId);
            Restrictions.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ActorId = reader.ReadDouble();
            Restrictions = new ActorRestrictionsInformations();
            Restrictions.Deserialize(reader);
        }
    }
}