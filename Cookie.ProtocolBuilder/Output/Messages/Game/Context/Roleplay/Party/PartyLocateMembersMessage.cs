namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Types.Game.Context.Roleplay.Party;
    using System.Collections.Generic;
    using Utils.IO;

    public class PartyLocateMembersMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5595;
        public override ushort MessageID => ProtocolId;
        public List<PartyMemberGeoPosition> Geopositions { get; set; }

        public PartyLocateMembersMessage(List<PartyMemberGeoPosition> geopositions)
        {
            Geopositions = geopositions;
        }

        public PartyLocateMembersMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Geopositions.Count);
            for (var geopositionsIndex = 0; geopositionsIndex < Geopositions.Count; geopositionsIndex++)
            {
                var objectToSend = Geopositions[geopositionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var geopositionsCount = reader.ReadUShort();
            Geopositions = new List<PartyMemberGeoPosition>();
            for (var geopositionsIndex = 0; geopositionsIndex < geopositionsCount; geopositionsIndex++)
            {
                var objectToAdd = new PartyMemberGeoPosition();
                objectToAdd.Deserialize(reader);
                Geopositions.Add(objectToAdd);
            }
        }

    }
}
