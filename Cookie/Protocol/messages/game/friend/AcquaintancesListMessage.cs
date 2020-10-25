using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AcquaintancesListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6820;
        public override uint MessageID { get { return ProtocolId; } }

        public List<AcquaintanceInformation> AcquaintanceList;

        public AcquaintancesListMessage()
        {
        }

        public AcquaintancesListMessage(
            List<AcquaintanceInformation> acquaintanceList
        )
        {
            AcquaintanceList = acquaintanceList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)AcquaintanceList.Count());
            foreach (var current in AcquaintanceList)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countAcquaintanceList = reader.ReadShort();
            AcquaintanceList = new List<AcquaintanceInformation>();
            for (short i = 0; i < countAcquaintanceList; i++)
            {
                var acquaintanceListtypeId = reader.ReadShort();
                AcquaintanceInformation type = new AcquaintanceInformation();
                type.Deserialize(reader);
                AcquaintanceList.Add(type);
            }
        }
    }
}