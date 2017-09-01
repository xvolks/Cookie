namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class EditHavenBagFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6628;
        public override ushort MessageID => ProtocolId;

        public EditHavenBagFinishedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
