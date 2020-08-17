using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharactersListMessage : BasicCharactersListMessage
    {
        public new const ushort ProtocolId = 151;

        public CharactersListMessage(bool hasStartupActions)
        {
            HasStartupActions = hasStartupActions;
        }

        public CharactersListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool HasStartupActions { get; set; }

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