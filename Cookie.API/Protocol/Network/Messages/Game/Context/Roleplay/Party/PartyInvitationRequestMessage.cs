namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyInvitationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5585;
        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }

        public PartyInvitationRequestMessage(string name)
        {
            Name = name;
        }

        public PartyInvitationRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
        }

    }
}
