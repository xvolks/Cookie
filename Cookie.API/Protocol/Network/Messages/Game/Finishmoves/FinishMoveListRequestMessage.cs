namespace Cookie.API.Protocol.Network.Messages.Game.Finishmoves
{
    using Utils.IO;

    public class FinishMoveListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6702;
        public override ushort MessageID => ProtocolId;

        public FinishMoveListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
