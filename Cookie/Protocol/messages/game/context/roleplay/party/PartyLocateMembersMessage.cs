using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyLocateMembersMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5595;
        public override uint MessageID { get { return ProtocolId; } }

        public List<PartyMemberGeoPosition> Geopositions;

        public PartyLocateMembersMessage(): base()
        {
        }

        public PartyLocateMembersMessage(
            int partyId,
            List<PartyMemberGeoPosition> geopositions
        ): base(
            partyId
        )
        {
            Geopositions = geopositions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Geopositions.Count());
            foreach (var current in Geopositions)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countGeopositions = reader.ReadShort();
            Geopositions = new List<PartyMemberGeoPosition>();
            for (short i = 0; i < countGeopositions; i++)
            {
                PartyMemberGeoPosition type = new PartyMemberGeoPosition();
                type.Deserialize(reader);
                Geopositions.Add(type);
            }
        }
    }
}