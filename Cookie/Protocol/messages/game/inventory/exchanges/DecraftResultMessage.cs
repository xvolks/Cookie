using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DecraftResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 6569;
        public override uint MessageID { get { return ProtocolId; } }

        public List<DecraftedItemStackInfo> Results;

        public DecraftResultMessage()
        {
        }

        public DecraftResultMessage(
            List<DecraftedItemStackInfo> results
        )
        {
            Results = results;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Results.Count());
            foreach (var current in Results)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countResults = reader.ReadShort();
            Results = new List<DecraftedItemStackInfo>();
            for (short i = 0; i < countResults; i++)
            {
                DecraftedItemStackInfo type = new DecraftedItemStackInfo();
                type.Deserialize(reader);
                Results.Add(type);
            }
        }
    }
}