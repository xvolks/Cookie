namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Utils.IO;

    public class PrismFightAttackerRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5897;
        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public ushort FightId { get; set; }
        public ulong FighterToRemoveId { get; set; }

        public PrismFightAttackerRemoveMessage(ushort subAreaId, ushort fightId, ulong fighterToRemoveId)
        {
            SubAreaId = subAreaId;
            FightId = fightId;
            FighterToRemoveId = fighterToRemoveId;
        }

        public PrismFightAttackerRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhShort(FightId);
            writer.WriteVarUhLong(FighterToRemoveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            FightId = reader.ReadVarUhShort();
            FighterToRemoveId = reader.ReadVarUhLong();
        }

    }
}
