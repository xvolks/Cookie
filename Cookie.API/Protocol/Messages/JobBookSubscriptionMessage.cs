using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobBookSubscriptionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6593;

        public override ushort MessageID => ProtocolId;

        public List<JobBookSubscription> Subscriptions { get; set; }
        public JobBookSubscriptionMessage() { }

        public JobBookSubscriptionMessage( List<JobBookSubscription> Subscriptions ){
            this.Subscriptions = Subscriptions;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Subscriptions.Count);
			foreach (var x in Subscriptions)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var SubscriptionsCount = reader.ReadShort();
            Subscriptions = new List<JobBookSubscription>();
            for (var i = 0; i < SubscriptionsCount; i++)
            {
                var objectToAdd = new JobBookSubscription();
                objectToAdd.Deserialize(reader);
                Subscriptions.Add(objectToAdd);
            }
        }
    }
}
