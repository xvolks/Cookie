using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class JobBookSubscriptionMessage : NetworkMessage
    {
        public const uint ProtocolId = 6593;
        public override uint MessageID { get { return ProtocolId; } }

        public List<JobBookSubscription> Subscriptions;

        public JobBookSubscriptionMessage()
        {
        }

        public JobBookSubscriptionMessage(
            List<JobBookSubscription> subscriptions
        )
        {
            Subscriptions = subscriptions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Subscriptions.Count());
            foreach (var current in Subscriptions)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countSubscriptions = reader.ReadShort();
            Subscriptions = new List<JobBookSubscription>();
            for (short i = 0; i < countSubscriptions; i++)
            {
                JobBookSubscription type = new JobBookSubscription();
                type.Deserialize(reader);
                Subscriptions.Add(type);
            }
        }
    }
}