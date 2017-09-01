namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightFighterCompanionLightInformations : GameFightFighterLightInformations
    {
        public new const ushort ProtocolId = 454;
        public override ushort TypeID => ProtocolId;
        public byte CompanionId { get; set; }
        public double MasterId { get; set; }

        public GameFightFighterCompanionLightInformations(byte companionId, double masterId)
        {
            CompanionId = companionId;
            MasterId = masterId;
        }

        public GameFightFighterCompanionLightInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(CompanionId);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CompanionId = reader.ReadByte();
            MasterId = reader.ReadDouble();
        }

    }
}
