namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    using Utils.IO;

    public class TitlesAndOrnamentsListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6363;
        public override ushort MessageID => ProtocolId;

        public TitlesAndOrnamentsListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
