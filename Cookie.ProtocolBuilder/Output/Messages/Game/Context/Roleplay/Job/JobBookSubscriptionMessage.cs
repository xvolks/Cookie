namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    using Types.Game.Context.Roleplay.Job;
    using System.Collections.Generic;
    using Utils.IO;

    public class JobBookSubscriptionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6593;
        public override ushort MessageID => ProtocolId;
        public List<JobBookSubscription> Subscriptions { get; set; }

        public JobBookSubscriptionMessage(List<JobBookSubscription> subscriptions)
        {
            Subscriptions = subscriptions;
        }

        public JobBookSubscriptionMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Subscriptions.Count);
            for (var subscriptionsIndex = 0; subscriptionsIndex < Subscriptions.Count; subscriptionsIndex++)
            {
                var objectToSend = Subscriptions[subscriptionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var subscriptionsCount = reader.ReadUShort();
            Subscriptions = new List<JobBookSubscription>();
            for (var subscriptionsIndex = 0; subscriptionsIndex < subscriptionsCount; subscriptionsIndex++)
            {
                var objectToAdd = new JobBookSubscription();
                objectToAdd.Deserialize(reader);
                Subscriptions.Add(objectToAdd);
            }
        }

    }
}
