using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharacterFirstSelectionMessage : CharacterSelectionMessage
    {
        public new const ushort ProtocolId = 6084;

        public CharacterFirstSelectionMessage(bool doTutorial)
        {
            DoTutorial = doTutorial;
        }

        public CharacterFirstSelectionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool DoTutorial { get; set; }

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