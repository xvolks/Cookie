namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Context;
    using Types.Game.Look;
    using Utils.IO;

    public class GameRolePlayNpcInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 156;
        public override ushort TypeID => ProtocolId;
        public ushort NpcId { get; set; }
        public bool Sex { get; set; }
        public ushort SpecialArtworkId { get; set; }

        public GameRolePlayNpcInformations(ushort npcId, bool sex, ushort specialArtworkId)
        {
            NpcId = npcId;
            Sex = sex;
            SpecialArtworkId = specialArtworkId;
        }

        public GameRolePlayNpcInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(NpcId);
            writer.WriteBoolean(Sex);
            writer.WriteVarUhShort(SpecialArtworkId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NpcId = reader.ReadVarUhShort();
            Sex = reader.ReadBoolean();
            SpecialArtworkId = reader.ReadVarUhShort();
        }

    }
}
