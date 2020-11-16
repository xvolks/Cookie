using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AcquaintancesListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6820;

        public override ushort MessageID => ProtocolId;

        public List<AcquaintanceInformation> AcquaintanceList { get; set; }
        public AcquaintancesListMessage() { }

        public AcquaintancesListMessage( List<AcquaintanceInformation> AcquaintanceList ){
            this.AcquaintanceList = AcquaintanceList;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)AcquaintanceList.Count);
			foreach (var x in AcquaintanceList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var AcquaintanceListCount = reader.ReadShort();
            AcquaintanceList = new List<AcquaintanceInformation>();
            for (var i = 0; i < AcquaintanceListCount; i++)
            {
                AcquaintanceInformation objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                AcquaintanceList.Add(objectToAdd);
            }
        }
    }
}
