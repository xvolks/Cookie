namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Utils.IO;

    public class MapFightCountMessage : NetworkMessage
    {
        public const ushort ProtocolId = 210;
        public override ushort MessageID => ProtocolId;
        public ushort FightCount { get; set; }

        public MapFightCountMessage(ushort fightCount)
        {
            FightCount = fightCount;
        }

        public MapFightCountMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightCount = reader.ReadVarUhShort();
        }

    }
}
