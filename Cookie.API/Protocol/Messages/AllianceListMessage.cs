using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6408;

        public override ushort MessageID => ProtocolId;

        public List<AllianceFactSheetInformations> Alliances { get; set; }
        public AllianceListMessage() { }

        public AllianceListMessage( List<AllianceFactSheetInformations> Alliances ){
            this.Alliances = Alliances;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Alliances.Count);
			foreach (var x in Alliances)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var AlliancesCount = reader.ReadShort();
            Alliances = new List<AllianceFactSheetInformations>();
            for (var i = 0; i < AlliancesCount; i++)
            {
                var objectToAdd = new AllianceFactSheetInformations();
                objectToAdd.Deserialize(reader);
                Alliances.Add(objectToAdd);
            }
        }
    }
}
