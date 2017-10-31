namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    using Utils.IO;

    public class CharacterFirstSelectionMessage : CharacterSelectionMessage
    {
        public new const ushort ProtocolId = 6084;
        public override ushort MessageID => ProtocolId;
        public bool DoTutorial { get; set; }

        public CharacterFirstSelectionMessage(bool doTutorial)
        {
            DoTutorial = doTutorial;
        }

        public CharacterFirstSelectionMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(DoTutorial);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DoTutorial = reader.ReadBoolean();
        }

    }
}
