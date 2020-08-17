using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyLeaderUpdateMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 5578;

        public PartyLeaderUpdateMessage(ulong partyLeaderId)
        {
            PartyLeaderId = partyLeaderId;
        }

        public PartyLeaderUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong PartyLeaderId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PartyLeaderId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyLeaderId = reader.ReadVarUhLong();
        }
    }
}