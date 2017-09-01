using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class GameFightCompanionInformations : GameFightFighterInformations
    {
        public new const ushort ProtocolId = 450;

        public GameFightCompanionInformations(byte companionGenericId, byte level, double masterId)
        {
            CompanionGenericId = companionGenericId;
            Level = level;
            MasterId = masterId;
        }

        public GameFightCompanionInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte CompanionGenericId { get; set; }
        public byte Level { get; set; }
        public double MasterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(CompanionGenericId);
            writer.WriteByte(Level);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CompanionGenericId = reader.ReadByte();
            Level = reader.ReadByte();
            MasterId = reader.ReadDouble();
        }
    }
}