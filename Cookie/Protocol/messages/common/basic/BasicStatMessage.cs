using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicStatMessage : NetworkMessage
    {
        public const uint ProtocolId = 6530;
        public override uint MessageID { get { return ProtocolId; } }

        public double TimeSpent = 0;
        public short StatId = 0;

        public BasicStatMessage()
        {
        }

        public BasicStatMessage(
            double timeSpent,
            short statId
        )
        {
            TimeSpent = timeSpent;
            StatId = statId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(TimeSpent);
            writer.WriteVarShort(StatId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TimeSpent = reader.ReadDouble();
            StatId = reader.ReadVarShort();
        }
    }
}