using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyKickedByMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5590;

        public PartyKickedByMessage(ulong kickerId)
        {
            KickerId = kickerId;
        }

        public PartyKickedByMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong KickerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(KickerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            KickerId = reader.ReadVarUhLong();
        }
    }
}