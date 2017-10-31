namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyCannotJoinErrorMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5583;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public PartyCannotJoinErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public PartyCannotJoinErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Reason = reader.ReadByte();
        }

    }
}
