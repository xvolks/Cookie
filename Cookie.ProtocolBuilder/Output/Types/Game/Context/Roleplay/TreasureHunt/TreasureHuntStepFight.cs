namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class TreasureHuntStepFight : TreasureHuntStep
    {
        public new const ushort ProtocolId = 462;
        public override ushort TypeID => ProtocolId;

        public TreasureHuntStepFight() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
