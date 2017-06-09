using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharactersListMessage : BasicCharactersListMessage
    {
        public new const uint ProtocolId = 151;
        public override uint MessageID { get { return ProtocolId; } }

        public bool HasStartupActions;

        public CharactersListMessage() { }

        public CharactersListMessage(bool hasStartupActions)
        {
            HasStartupActions = hasStartupActions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(HasStartupActions);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            HasStartupActions = reader.ReadBoolean();
        }
    }
}
