using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceVersatileInfoListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6436;

        public override ushort MessageID => ProtocolId;

        public List<AllianceVersatileInformations> Alliances { get; set; }
        public AllianceVersatileInfoListMessage() { }

        public AllianceVersatileInfoListMessage( List<AllianceVersatileInformations> Alliances ){
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
            Alliances = new List<AllianceVersatileInformations>();
            for (var i = 0; i < AlliancesCount; i++)
            {
                var objectToAdd = new AllianceVersatileInformations();
                objectToAdd.Deserialize(reader);
                Alliances.Add(objectToAdd);
            }
        }
    }
}
