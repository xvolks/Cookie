using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachBudgetMessage : NetworkMessage
    {
        public const uint ProtocolId = 6786;
        public override uint MessageID { get { return ProtocolId; } }

        public int Bugdet = 0;

        public BreachBudgetMessage()
        {
        }

        public BreachBudgetMessage(
            int bugdet
        )
        {
            Bugdet = bugdet;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Bugdet);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Bugdet = reader.ReadVarInt();
        }
    }
}