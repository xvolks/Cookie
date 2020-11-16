using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DecraftResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6569;

        public override ushort MessageID => ProtocolId;

        public List<DecraftedItemStackInfo> Results { get; set; }
        public DecraftResultMessage() { }

        public DecraftResultMessage( List<DecraftedItemStackInfo> Results ){
            this.Results = Results;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Results.Count);
			foreach (var x in Results)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ResultsCount = reader.ReadShort();
            Results = new List<DecraftedItemStackInfo>();
            for (var i = 0; i < ResultsCount; i++)
            {
                var objectToAdd = new DecraftedItemStackInfo();
                objectToAdd.Deserialize(reader);
                Results.Add(objectToAdd);
            }
        }
    }
}
