using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharactersListMessage : BasicCharactersListMessage
    {
        public new const uint ProtocolId = 151;

        public bool HasStartupActions;

        public CharactersListMessage()
        {
        }

        public CharactersListMessage(bool hasStartupActions)
        {
            HasStartupActions = hasStartupActions;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(HasStartupActions);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HasStartupActions = reader.ReadBoolean();
        }
    }
}