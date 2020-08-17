namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Types.Game.Character;
    using Utils.IO;

    public class PrismFightDefenderAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5895;
        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public ushort FightId { get; set; }
        public CharacterMinimalPlusLookInformations Defender { get; set; }

        public PrismFightDefenderAddMessage(ushort subAreaId, ushort fightId, CharacterMinimalPlusLookInformations defender)
        {
            SubAreaId = subAreaId;
            FightId = fightId;
            Defender = defender;
        }

        public PrismFightDefenderAddMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhShort(FightId);
            writer.WriteUShort(Defender.TypeID);
            Defender.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            FightId = reader.ReadVarUhShort();
            Defender = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadUShort());
            Defender.Deserialize(reader);
        }

    }
}
