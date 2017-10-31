namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using Utils.IO;

    public class GuidedModeReturnRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6088;
        public override ushort MessageID => ProtocolId;

        public GuidedModeReturnRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
