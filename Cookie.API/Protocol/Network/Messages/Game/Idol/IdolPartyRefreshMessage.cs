using Cookie.API.Protocol.Network.Types.Game.Idol;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Idol
{
    public class IdolPartyRefreshMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6583;

        public IdolPartyRefreshMessage(PartyIdol partyIdol)
        {
            PartyIdol = partyIdol;
        }

        public IdolPartyRefreshMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public PartyIdol PartyIdol { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            PartyIdol.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PartyIdol = new PartyIdol();
            PartyIdol.Deserialize(reader);
        }
    }
}