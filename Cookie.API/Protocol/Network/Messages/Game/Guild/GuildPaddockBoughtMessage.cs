namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using Types.Game.Paddock;
    using Utils.IO;

    public class GuildPaddockBoughtMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5952;
        public override ushort MessageID => ProtocolId;
        public PaddockContentInformations PaddockInfo { get; set; }

        public GuildPaddockBoughtMessage(PaddockContentInformations paddockInfo)
        {
            PaddockInfo = paddockInfo;
        }

        public GuildPaddockBoughtMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            PaddockInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockInfo = new PaddockContentInformations();
            PaddockInfo.Deserialize(reader);
        }

    }
}
