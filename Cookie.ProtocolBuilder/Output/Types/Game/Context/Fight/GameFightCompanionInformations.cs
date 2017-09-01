namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Types.Game.Context;
    using Types.Game.Look;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameFightCompanionInformations : GameFightFighterInformations
    {
        public new const ushort ProtocolId = 450;
        public override ushort TypeID => ProtocolId;
        public byte CompanionGenericId { get; set; }
        public byte Level { get; set; }
        public double MasterId { get; set; }

        public GameFightCompanionInformations(byte companionGenericId, byte level, double masterId)
        {
            CompanionGenericId = companionGenericId;
            Level = level;
            MasterId = masterId;
        }

        public GameFightCompanionInformations() { }

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
