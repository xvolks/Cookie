namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class TreasureHuntStepFollowDirectionToHint : TreasureHuntStep
    {
        public new const ushort ProtocolId = 472;
        public override ushort TypeID => ProtocolId;
        public byte Direction { get; set; }
        public ushort NpcId { get; set; }

        public TreasureHuntStepFollowDirectionToHint(byte direction, ushort npcId)
        {
            Direction = direction;
            NpcId = npcId;
        }

        public TreasureHuntStepFollowDirectionToHint() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Direction);
            writer.WriteVarUhShort(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Direction = reader.ReadByte();
            NpcId = reader.ReadVarUhShort();
        }

    }
}
