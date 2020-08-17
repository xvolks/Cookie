namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class EditHavenBagCancelRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6619;
        public override ushort MessageID => ProtocolId;

        public EditHavenBagCancelRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
