using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyLocateMembersMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5595;

        public override ushort MessageID => ProtocolId;

        public List<PartyMemberGeoPosition> Geopositions { get; set; }
        public PartyLocateMembersMessage() { }

        public PartyLocateMembersMessage( List<PartyMemberGeoPosition> Geopositions ){
            this.Geopositions = Geopositions;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Geopositions.Count);
			foreach (var x in Geopositions)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var GeopositionsCount = reader.ReadShort();
            Geopositions = new List<PartyMemberGeoPosition>();
            for (var i = 0; i < GeopositionsCount; i++)
            {
                var objectToAdd = new PartyMemberGeoPosition();
                objectToAdd.Deserialize(reader);
                Geopositions.Add(objectToAdd);
            }
        }
    }
}
