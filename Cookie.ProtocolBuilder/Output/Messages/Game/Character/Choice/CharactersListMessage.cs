namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    using Types.Game.Character.Choice;
    using System.Collections.Generic;
    using Utils.IO;

    public class CharactersListMessage : BasicCharactersListMessage
    {
        public new const ushort ProtocolId = 151;
        public override ushort MessageID => ProtocolId;
        public bool HasStartupActions { get; set; }

        public CharactersListMessage(bool hasStartupActions)
        {
            HasStartupActions = hasStartupActions;
        }

        public CharactersListMessage() { }

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
