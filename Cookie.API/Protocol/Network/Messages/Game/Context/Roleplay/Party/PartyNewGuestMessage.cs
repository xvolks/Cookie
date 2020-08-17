using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyNewGuestMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 6260;

        public PartyNewGuestMessage(PartyGuestInformations guest)
        {
            Guest = guest;
        }

        public PartyNewGuestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public PartyGuestInformations Guest { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Guest.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Guest = new PartyGuestInformations();
            Guest.Deserialize(reader);
        }
    }
}