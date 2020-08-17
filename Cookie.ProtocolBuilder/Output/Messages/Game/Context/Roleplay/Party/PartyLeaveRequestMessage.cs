namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyLeaveRequestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5593;
        public override ushort MessageID => ProtocolId;

        public PartyLeaveRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
