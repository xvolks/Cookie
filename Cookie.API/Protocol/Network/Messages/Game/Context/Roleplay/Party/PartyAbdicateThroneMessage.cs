using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyAbdicateThroneMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6080;

        public PartyAbdicateThroneMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public PartyAbdicateThroneMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
        }
    }
}