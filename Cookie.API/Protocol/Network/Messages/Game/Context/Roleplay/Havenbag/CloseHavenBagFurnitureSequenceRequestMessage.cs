namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class CloseHavenBagFurnitureSequenceRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6621;
        public override ushort MessageID => ProtocolId;

        public CloseHavenBagFurnitureSequenceRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
