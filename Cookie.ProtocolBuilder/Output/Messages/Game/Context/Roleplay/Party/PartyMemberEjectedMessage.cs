namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyMemberEjectedMessage : PartyMemberRemoveMessage
    {
        public new const ushort ProtocolId = 6252;
        public override ushort MessageID => ProtocolId;
        public ulong KickerId { get; set; }

        public PartyMemberEjectedMessage(ulong kickerId)
        {
            KickerId = kickerId;
        }

        public PartyMemberEjectedMessage() { }

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
