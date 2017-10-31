namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    using Types.Game.Character.Choice;
    using Utils.IO;

    public class CharacterSelectionWithRemodelMessage : CharacterSelectionMessage
    {
        public new const ushort ProtocolId = 6549;
        public override ushort MessageID => ProtocolId;
        public RemodelingInformation Remodel { get; set; }

        public CharacterSelectionWithRemodelMessage(RemodelingInformation remodel)
        {
            Remodel = remodel;
        }

        public CharacterSelectionWithRemodelMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Remodel.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Remodel = new RemodelingInformation();
            Remodel.Deserialize(reader);
        }

    }
}
