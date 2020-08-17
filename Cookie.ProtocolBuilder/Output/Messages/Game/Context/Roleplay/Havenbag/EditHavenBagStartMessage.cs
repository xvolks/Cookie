namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class EditHavenBagStartMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6632;
        public override ushort MessageID => ProtocolId;

        public EditHavenBagStartMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
