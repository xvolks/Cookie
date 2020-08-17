namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Utils.IO;

    public class StopToListenRunningFightRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6124;
        public override ushort MessageID => ProtocolId;

        public StopToListenRunningFightRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
