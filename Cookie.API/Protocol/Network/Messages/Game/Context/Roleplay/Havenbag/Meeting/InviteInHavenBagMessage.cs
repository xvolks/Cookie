namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    using Types.Game.Character;
    using Utils.IO;

    public class InviteInHavenBagMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6642;
        public override ushort MessageID => ProtocolId;
        public CharacterMinimalInformations GuestInformations { get; set; }
        public bool Accept { get; set; }

        public InviteInHavenBagMessage(CharacterMinimalInformations guestInformations, bool accept)
        {
            GuestInformations = guestInformations;
            Accept = accept;
        }

        public InviteInHavenBagMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            GuestInformations.Serialize(writer);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuestInformations = new CharacterMinimalInformations();
            GuestInformations.Deserialize(reader);
            Accept = reader.ReadBoolean();
        }

    }
}
