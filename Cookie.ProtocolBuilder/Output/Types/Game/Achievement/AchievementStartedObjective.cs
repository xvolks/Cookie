namespace Cookie.API.Protocol.Network.Types.Game.Achievement
{
    using Utils.IO;

    public class AchievementStartedObjective : AchievementObjective
    {
        public new const ushort ProtocolId = 402;
        public override ushort TypeID => ProtocolId;
        public ushort Value { get; set; }

        public AchievementStartedObjective(ushort value)
        {
            Value = value;
        }

        public AchievementStartedObjective() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadVarUhShort();
        }

    }
}
